using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Resolve.Infra.Data.Models;

public class OrcamentoDespesa
{
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrcamentoDespesaId { get; set; }

    public int Codigo { get; set; }

    public string? Ficha { get; set; }

    public short Ano { get; set; }

    public decimal Valor { get; set; }

    public DateOnly DataCriacao { get; set; }

    public int UnidadeGestora { get; set; }

    public string? ElencoContaCodigo { get; set; }

    public int? FonteRecurso { get; set; }

    public int? Numero { get; set; }

    public OrcamentoDespesa() { }
}
