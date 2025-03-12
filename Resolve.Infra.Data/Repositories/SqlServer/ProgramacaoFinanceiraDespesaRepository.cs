using Microsoft.EntityFrameworkCore;
using Resolve.Domain.Registrations.Entities;
using Resolve.Domain.Registrations.Repositories;
using Resolve.Domain.Registrations.ViewModels.ProgramacaoFinanceiraDespesaConfig;
using Resolve.Domain.Registrations.ViewModels.ProgressaoMensalViewModel;
using Resolve.Infra.Data.Context;

namespace Resolve.Infra.Data.Repositories.SqlServer
{
    public class ProgramacaoFinanceiraDespesaRepository : IProgramacaoFinanceiraDespesaRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramacaoFinanceiraDespesaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate(ProgramacaoFinanceiraDespesaConfig programacao)
        {
            
                var existing = _context.ProgramacaoFinanceiraDespesaConfig
                .FirstOrDefault(x => x.ProgramacaoFinanceiraDespesaConfigId == programacao.ProgramacaoFinanceiraDespesaConfigId);

                if (existing == null)
                {
                    _context.ProgramacaoFinanceiraDespesaConfig.Add(programacao);
                }
                else
                {
                    _context.ProgramacaoFinanceiraDespesaConfig.Update(programacao);
                }

                _context.SaveChanges();
            
        }

        public async Task<ProgressaoMensalViewModel?> CalcularProgressoMensal(int ano, int unidadeGestoraId)
        {
            var programacao = await _context.ProgramacaoFinanceiraDespesaConfig
                .FirstOrDefaultAsync(x => x.Ano == ano && x.UnidadeGestoraIdfk == unidadeGestoraId);

            if (programacao == null) return null;

            decimal valorTotalOrcado = await _context.OrcamentoDespesa
                .Where(o => o.Ano == ano && o.UnidadeGestora == unidadeGestoraId)
                .SumAsync(o => o.Valor);

            if (valorTotalOrcado == 0) return null;

            var valoresMensais = new List<decimal>
            {
                Math.Round((programacao.Mes01Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes02Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes03Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes04Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes05Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes06Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes07Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes08Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes09Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes10Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes11Perc / 100) * valorTotalOrcado, 2),
                Math.Round((programacao.Mes12Perc / 100) * valorTotalOrcado, 2)
            };

            decimal somaMensal = valoresMensais.Sum();
            decimal diferenca = valorTotalOrcado - somaMensal;

            if (diferenca != 0)
            {
                valoresMensais[11] += diferenca;
            }

            return new ProgressaoMensalViewModel
            {
                Ano = programacao.Ano,
                UnidadeGestoraIdfk = programacao.UnidadeGestoraIdfk,
                Meses = valoresMensais,
                ValorTotal = valoresMensais.Sum()
            };
        }

        public async Task DeleteAsync(int id)
        {
            var programacao = await _context.ProgramacaoFinanceiraDespesaConfig.FindAsync(id);
            if (programacao != null)
            {
                _context.ProgramacaoFinanceiraDespesaConfig.Remove(programacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int orcamentoDespesaId, int unidadeGestoraId)
        {
                return await _context.ProgramacaoFinanceiraDespesaConfig
        .AnyAsync(x => x.ProgramacaoFinanceiraDespesaConfigId == orcamentoDespesaId && x.UnidadeGestoraIdfk == unidadeGestoraId);
        }

        public ProgramacaoFinanceiraDespesaConfig? GetById(int id)
        {
            var model = _context.ProgramacaoFinanceiraDespesaConfig.Find(id);
            return model;
        }
    }
}
