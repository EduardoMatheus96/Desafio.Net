using Resolve.Domain.Core.Command;

namespace Resolve.Domain.Registrations.Commands.ProgramacaoFinanceiraDespesaConfig
{
    public class UpdateProgramacaoFinanceiraDespesaConfigCommand : BaseCommand
    {
        public int Id { get; set; }
        public short Ano { get; set; }
        public int UnidadeGestoraIdfk { get; set; }
        public decimal Mes01Perc { get; set; }
        public decimal Mes02Perc { get; set; }
        public decimal Mes03Perc { get; set; }
        public decimal Mes04Perc { get; set; }
        public decimal Mes05Perc { get; set; }
        public decimal Mes06Perc { get; set; }
        public decimal Mes07Perc { get; set; }
        public decimal Mes08Perc { get; set; }
        public decimal Mes09Perc { get; set; }
        public decimal Mes10Perc { get; set; }
        public decimal Mes11Perc { get; set; }
        public decimal Mes12Perc { get; set; }
    }
}
