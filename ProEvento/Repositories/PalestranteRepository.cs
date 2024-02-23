using Microsoft.EntityFrameworkCore;
using ProEvento.Data;
using ProEvento.Interfaces;
using ProEvento.models;

namespace ProEvento.Repositories;

public class PalestranteRepository(AppDbContext context) : IPalestranteRepository
{
    AppDbContext IBaseRepository<Palestrante>._context => _context;

    private readonly AppDbContext _context = context;

    public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos, bool asNoTracking)
    {
        IQueryable<Palestrante> query = _context.Palestrantes.OrderBy(x => x.Nome)
                                                .Include(x => x.RedesSociais);
        if(includeEventos)
            query.Include(x => x.Eventos);

        return asNoTracking? query.AsNoTracking().ToArrayAsync() : query.ToArrayAsync();
    }

    public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos, bool asNoTracking)
    {
        IQueryable<Palestrante> query = _context.Palestrantes.Where(x => x.Nome != default && x.Nome.Any(e => e.Equals(nome)))
                                                            .Include(x => x.RedesSociais);
        if(includeEventos)
            query.Include(x => x.Eventos);

        return asNoTracking? query.AsNoTracking().ToArrayAsync(): query.ToArrayAsync();                                                
    }

    public async Task<Palestrante> GetPalestranteById(int id, bool includeEventos, bool asNoTracking)
    {
        var entity = await _context.Palestrantes.Where(x => x.Id == id).FirstOrDefaultAsync();
        
        return entity ?? throw new Exception("Registro não encontrado");
    }
}