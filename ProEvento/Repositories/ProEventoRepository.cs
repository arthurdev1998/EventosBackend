#nullable disable

using Microsoft.EntityFrameworkCore;
using ProEvento.Data;
using ProEvento.Interfaces;
using ProEvento.models;

namespace ProEvento.Repositories;

public class ProEventoRepository : IProEventoRepository
{
    private readonly AppDbContext _context;

    public ProEventoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Set<T>().Remove(entity);
    }

    public void DeleteRange<T>(T[] entity) where T : class
    {
        _context.Set<T>().RemoveRange(entity);
    }

    public async Task<Evento[]> GetAllEventosAsync(bool inclutePalestrantes = false, bool asNoTracking = false)
    {
        IQueryable<Evento> query = _context.Evento
                                        .Include(x => x.Lote)
                                        .Include(x => x.RedesSociais);

        if (inclutePalestrantes)
            query.Include(x => x.Palestrantes);

        return await query.ToArrayAsync();
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool inclutePalestrantes = false, bool asNoTracking = false)
    {
        IQueryable<Evento> query = _context.Evento
                                        .Include(x => x.Lote)
                                        .Include(x => x.RedesSociais);

        if (inclutePalestrantes)
            query.Include(x => x.Palestrantes);

        query = query.Where(x => x.Tema != null && x.Tema.Contains(tema, StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x.Tema);

        return asNoTracking ? await query.AsNoTracking().ToArrayAsync() :
                              await query.ToArrayAsync();
    }

    public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false, bool asNoTracking = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes.Order()
                                        .Include(x => x.RedesSociais);

        if (includeEventos)
            query.Include(x => x.Eventos);


        return asNoTracking ? await query.AsNoTracking().ToArrayAsync() : await query.ToArrayAsync();
    }

    public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false, bool asNoTracking = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes.OrderBy(x => x.Nome)
                                        .Include(x => x.RedesSociais);

        if (query.Any(x => x.Nome != null))
            query = query.Where(x => x.Nome != null && x.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase));

        if (includeEventos)
            query = query.Include(x => x.Eventos);

        return asNoTracking ? query.AsNoTracking().ToArrayAsync() : query.ToArrayAsync();
    }

    public async Task<Evento> GetEventoById(int id, bool inclutePalestrantes = false, bool asNoTracking = false)
    {
        return (await GetEventoById([id], inclutePalestrantes, asNoTracking)).FirstOrDefault();
    }

    public async Task<Evento[]> GetEventoById(int[] ids, bool inclutePalestrantes = false, bool asNoTracking = false)
    {
        return await _context.Evento
        .Include(x => x.Lote)
        .Include(x => x.RedesSociais)
        .Where(x => ids.Contains(x.Id)).ToArrayAsync();
    }

    public async Task<Palestrante> GetPalestranteById(int id, bool includeEventos = false, bool asNoTracking = false)
    {
        return (await GetPalestranteById([id], includeEventos, asNoTracking)).FirstOrDefault();
    }

    public async Task<Palestrante[]> GetPalestranteById(int[] ids, bool includeEventos = false, bool asNoTracking = false)
    {
        var query = _context.Palestrantes.Include(x => x.RedesSociais)
                                         .Where(x => ids.Contains(x.Id));

        if (includeEventos)
            query.Include(x => x.Eventos);

        return asNoTracking ? await query.AsNoTracking().ToArrayAsync() : await query.ToArrayAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Set<T>().Update(entity);
    }
}