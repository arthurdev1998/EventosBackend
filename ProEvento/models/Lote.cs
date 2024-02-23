namespace ProEvento.models
{
    public class Lote
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Qtd { get; set; }
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }
    }
}