using ProEvento.models;

namespace ProEvento.Interfaces;

public interface IPalestranteRepository : IBaseRepository<Palestrante>
{
    Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos, bool asNoTracking);
    Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos, bool asNoTracking);
    Task<Palestrante> GetPalestranteById(int id, bool includeEventos, bool asNoTracking);
}