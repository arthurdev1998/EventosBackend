using Microsoft.EntityFrameworkCore;
using ProEvento.Data;
using ProEvento.Interfaces;
using ProEvento.models;

namespace ProEvento.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly AppDbContext _context;

    public EventoRepository(AppDbContext context)
    {
        _context = context;
    }

    AppDbContext IBaseRepository<Evento>._context => _context;


    public async Task<Evento[]> GetAllEventosAsync(bool inclutePalestrantes, bool asNoTracking)
    {
        IQueryable<Evento> query = _context.Evento.Include(x => x.RedesSociais);
        if (inclutePalestrantes)
        {
            query.Include(x => x.Palestrantes);
        }

        return asNoTracking ? await query.AsNoTracking().ToArrayAsync() : await query.ToArrayAsync();
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool inclutePalestrantes, bool asNoTracking)
    {
        IQueryable<Evento> query = _context.Evento.OrderBy(x => x.Tema)
                                    .Where(x => x.Tema != null && x.Tema.Contains(tema))
                                    .Include(x => x.RedesSociais);

        if (inclutePalestrantes)
        {
            query.Include(x => x.Palestrantes);
        }

        return asNoTracking ? await query.AsNoTracking().ToArrayAsync() : await query.ToArrayAsync();
    }

    public async Task<Evento> GetEventoById(int id, bool inclutePalestrantes, bool asNoTracking)
    {
        var query =  (await GetEventoById([id], inclutePalestrantes, asNoTracking)).FirstOrDefault();
        
        return query != default? query : throw new Exception();
    }

    public async Task<Evento[]> GetEventoById(int[] ids, bool inclutePalestrantes, bool asNoTracking)
    {
        var query = _context.Evento.Where(x => ids.Contains(x.Id)).Include(x => x.RedesSociais);
        
        if(inclutePalestrantes)
                query.Include(x => x.Palestrantes);
        
        return asNoTracking? await query.AsNoTracking().ToArrayAsync() : await query.ToArrayAsync();
    }

    async Task<Evento[]> IEventoRepository.GetAllEventosAsync(bool inclutePalestrantes, bool asNoTracking)
    {
        IQueryable<Evento> query = _context.Evento.Include(x => x.RedesSociais);
        if(inclutePalestrantes)
            query.Include(x => x.Palestrantes);

            return asNoTracking? await query.AsNoTracking().ToArrayAsync() : await query.ToArrayAsync();
    }

    async Task<Evento[]> IEventoRepository.GetAllEventosByTemaAsync(string tema, bool inclutePalestrantes, bool asNoTracking)
    {
        IQueryable<Evento> query = _context.Evento.Where(x => x.Tema != default && x.Tema.Contains(tema))
                                                    .OrderBy(x => x.Tema)
                                                    .Include(x => x.RedesSociais);
        
        if(inclutePalestrantes)
            query.Include(x => x.Palestrantes);
        
        return asNoTracking? await query.AsNoTracking().ToArrayAsync() : await query.ToArrayAsync();
    }
}
