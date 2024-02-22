using ProEvento.Data;
using ProEvento.models;

namespace ProEvento.Interfaces;

public interface IBaseRepository<T> where T : class
{
    protected AppDbContext _context { get; }
    
    void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
    void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    void DeleteRange(T[] entity)
    {
        _context.Set<T>().RemoveRange(entity);
    }
    async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >0;
    }
}