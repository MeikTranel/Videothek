using System.Collections.Generic;

namespace Videothek.Persistence
{
    public interface IQueryableDataProvider<out TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Entities { get; }
    }
}