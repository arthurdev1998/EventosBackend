namespace ProEvento.Interfaces;

public interface IUnitofWork : IDisposable
{
    public Task<bool> Commit();
}
