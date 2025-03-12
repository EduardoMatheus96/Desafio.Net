using Resolve.Domain.Registrations.Entities;
using Resolve.Domain.Registrations.ViewModels.ProgressaoMensalViewModel;

namespace Resolve.Domain.Registrations.Repositories
{
    public interface IProgramacaoFinanceiraDespesaRepository
    {
        ProgramacaoFinanceiraDespesaConfig? GetById(int id);
        void AddOrUpdate(ProgramacaoFinanceiraDespesaConfig programacao);
        Task DeleteAsync(int id);
        Task<bool> Exists(int orcamentoDespesaId, int unidadeGestoraId);
        Task<ProgressaoMensalViewModel?> CalcularProgressoMensal(int ano, int unidadeGestoraId);
    }
}
