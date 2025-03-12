using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Resolve.Domain.Registrations.Commands.ProgramacaoFinanceiraDespesaConfig;

namespace Resolve.Domain.Registrations.Entities
{
    public class ProgramacaoFinanceiraDespesaConfig : BaseEntity
    {
        public short Ano { get; private set; }
        public int UnidadeGestoraIdfk { get; private set; }
        public decimal Mes01Perc { get; private set; }
        public decimal Mes02Perc { get; private set; }
        public decimal Mes03Perc { get; private set; }
        public decimal Mes04Perc { get; private set; }
        public decimal Mes05Perc { get; private set; }
        public decimal Mes06Perc { get; private set; }
        public decimal Mes07Perc { get; private set; }
        public decimal Mes08Perc { get; private set; }
        public decimal Mes09Perc { get; private set; }
        public decimal Mes10Perc { get; private set; }
        public decimal Mes11Perc { get; private set; }
        public decimal Mes12Perc { get; private set; }

        public ProgramacaoFinanceiraDespesaConfig() { }

        public ProgramacaoFinanceiraDespesaConfig(CreateProgramacaoFinanceiraDespesaConfigCommand command)
        {
            ProgramacaoFinanceiraDespesaConfigId = command.ProgramacaoFinanceiraDespesaConfigId;
            Ano = command.Ano;
            UnidadeGestoraIdfk = command.UnidadeGestoraIdfk;
            Mes01Perc = command.Mes01Perc;
            Mes02Perc = command.Mes02Perc;
            Mes03Perc = command.Mes03Perc;
            Mes04Perc = command.Mes04Perc;
            Mes05Perc = command.Mes05Perc;
            Mes06Perc = command.Mes06Perc;
            Mes07Perc = command.Mes07Perc;
            Mes08Perc = command.Mes08Perc;
            Mes09Perc = command.Mes09Perc;
            Mes10Perc = command.Mes10Perc;
            Mes11Perc = command.Mes11Perc;
            Mes12Perc = command.Mes12Perc;
           
        }

        public void Update(
            UpdateProgramacaoFinanceiraDespesaConfigCommand command)
        {
            Ano = command.Ano;
            UnidadeGestoraIdfk = command.UnidadeGestoraIdfk;
            Mes01Perc = command.Mes01Perc;
            Mes02Perc = command.Mes02Perc;
            Mes03Perc = command.Mes03Perc;
            Mes04Perc = command.Mes04Perc;
            Mes05Perc = command.Mes05Perc;
            Mes06Perc = command.Mes06Perc;
            Mes07Perc = command.Mes07Perc;
            Mes08Perc = command.Mes08Perc;
            Mes09Perc = command.Mes09Perc;
            Mes10Perc = command.Mes10Perc;
            Mes11Perc = command.Mes11Perc;
            Mes12Perc = command.Mes12Perc;
        }

        public static ProgramacaoFinanceiraDespesaConfig Create(CreateProgramacaoFinanceiraDespesaConfigCommand command) => new ProgramacaoFinanceiraDespesaConfig(command);

    }
}
