using System.Linq.Expressions;
using ProEvento.Data;

namespace ProEvento.models;

public interface IPowerQueryRunner<TEntity> where TEntity : class
{
    protected AppDbContext _db {get;}

    public async ValueTask<PowerQueryResultDto<TEntity>> QueryAsync(PowerQueryExecuteDto queryExecuteDto
    , params Expression<Func<TEntity, object>>[] customIncludes )
    {
        return null;
    }
}