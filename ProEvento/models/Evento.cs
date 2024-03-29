using System.ComponentModel.DataAnnotations.Schema;

namespace ProEvento.models;

[Table("evento")]
public class Evento
{
    public int Id { get; set; }
    public string? Local { get; set; }
    public DateTime DataEvento { get; set; }
    public string? Tema { get; set; }
    public int QtdPessoas { get; set; }
    public string? Lote { get; set; }
    public string? ImagemUrl { get; set; }

    public ICollection<RedeSocial>? RedesSociais { get; set; }
    public ICollection<Palestrante>? Palestrantes { get; set; }
}