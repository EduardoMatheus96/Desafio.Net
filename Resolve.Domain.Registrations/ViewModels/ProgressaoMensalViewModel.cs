namespace Resolve.Domain.Registrations.ViewModels.ProgressaoMensalViewModel
{
    public class ProgressaoMensalViewModel
    {
        public short Ano { get; set; }
        public int UnidadeGestoraIdfk { get; set; }
        public List<decimal> Meses { get; set; }
        public decimal ValorTotal { get; set; }
    }


}
