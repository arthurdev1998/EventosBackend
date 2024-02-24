using ProEvento.Data;

namespace ProEvento.Interfaces;

public interface IBaseRepository<T> where T : class
{
    protected AppDbContext _context { get; }
    
    async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
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