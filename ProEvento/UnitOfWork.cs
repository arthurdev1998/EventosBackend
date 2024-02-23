using ProEvento.Data;
using ProEvento.Interfaces;

namespace ProEvento;

public class UnitOfWork : IUnitofWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();


    async Task<bool> IUnitofWork.Commit()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
