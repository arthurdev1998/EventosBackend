using ProEvento.models;

namespace ProEvento.Interfaces;

public interface IEventoRepository : IBaseRepository<Evento>
{
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool inclutePalestrantes = false, bool asNoTracking = false);
    Task<Evento[]> GetAllEventosAsync(bool inclutePalestrantes = false, bool asNoTracking = false);
    Task<Evento> GetEventoById(int id, bool inclutePalestrantes = false, bool asNoTracking = false);
}