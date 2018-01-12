using System.Collections.Generic;

namespace Videothek.Persistence
{
    public interface IRepository<out TEntity> where TEntity : class
    {
        TEntity Get(string key);
        IEnumerable<TEntity> Fetch();
    }
}