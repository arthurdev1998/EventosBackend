using ProEvento.models;

namespace ProEvento.Interfaces;

public interface IEventoRepository : IBaseRepository<Evento>
{
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool inclutePalestrantes, bool asNoTracking);
    Task<Evento[]> GetAllEventosAsync(bool inclutePalestrantes, bool asNoTracking);
    Task<Evento> GetEventoById(int id, bool inclutePalestrantes, bool asNoTracking);
}