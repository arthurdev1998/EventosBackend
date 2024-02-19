namespace ProEvento.models;

public class Palestrante
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Curriculo { get; set; }
    public string? ImagemUrl { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public IEnumerable<RedeSocial>? RedesSociais { get; set; }
    public ICollection<Evento>? Eventos { get; set; }
}