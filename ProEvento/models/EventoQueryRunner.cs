using ProEvento.Data;

namespace ProEvento.models;

public class EventoQueryRunner : IEventoQueryRunner
{
    private readonly AppDbContext _db;
    AppDbContext IPowerQueryRunner<Evento>._db => _db;

    public EventoQueryRunner(AppDbContext db)
    {
        _db = db;
    }
}