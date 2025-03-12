namespace Resolve.Domain.Registrations.ViewModels.ProgramacaoFinanceiraDespesaConfig
{
    public class ProgramacaoFinanceiraDespesaConfigViewModel
    {
        public int UnidadeGestoraId { get; set; }
        public short Ano { get; set; }
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

        public ProgramacaoFinanceiraDespesaConfigViewModel(
            int unidadeGestoraId, short ano, decimal mes01Perc, decimal mes02Perc,
            decimal mes03Perc, decimal mes04Perc, decimal mes05Perc, decimal mes06Perc,
            decimal mes07Perc, decimal mes08Perc, decimal mes09Perc, decimal mes10Perc,
            decimal mes11Perc, decimal mes12Perc)
        {
            UnidadeGestoraId = unidadeGestoraId;
            Ano = ano;
            Mes01Perc = mes01Perc;
            Mes02Perc = mes02Perc;
            Mes03Perc = mes03Perc;
            Mes04Perc = mes04Perc;
            Mes05Perc = mes05Perc;
            Mes06Perc = mes06Perc;
            Mes07Perc = mes07Perc;
            Mes08Perc = mes08Perc;
            Mes09Perc = mes09Perc;
            Mes10Perc = mes10Perc;
            Mes11Perc = mes11Perc;
            Mes12Perc = mes12Perc;
        }
    }
}
