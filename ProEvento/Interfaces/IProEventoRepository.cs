using ProEvento.models;

namespace ProEvento.Interfaces;

public interface IProEventoRepository
{
    void Add<T>(T entity) where T: class;
    void Update<T>(T entity) where T: class;
    void Delete<T>(T entity) where T: class;
    void DeleteRange<T>(T[] entity) where T: class;
    
    Task<bool> SaveChangesAsync();

    //Eventos

    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool inclutePalestrantes, bool asNoTracking);
    Task<Evento[]> GetAllEventosAsync( bool inclutePalestrantes, bool asNoTracking);
    Task<Evento> GetEventoById(int id, bool inclutePalestrantes, bool asNoTracking);

    //Palestrantes

    Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos, bool asNoTracking);
    Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos, bool asNoTracking);
    Task<Palestrante> GetPalestranteById(int id, bool includeEventos, bool asNoTracking);

}