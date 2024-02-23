using ProEvento.models;

namespace ProEvento.Interfaces;

public interface IPalestranteRepository : IBaseRepository<Palestrante>
{
    Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome = "", bool includeEventos = false, bool asNoTracking = false);
    Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false, bool asNoTracking = false);
    Task<Palestrante> GetPalestranteById(int id, bool includeEventos = false, bool asNoTracking = false);
}