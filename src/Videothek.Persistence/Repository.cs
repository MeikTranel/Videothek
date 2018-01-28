using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SQLite;

namespace Videothek.Persistence
{
    public class Repository<T> where T : class,new()
    {
        private readonly Database _database;

        private SQLiteConnection GetConnection() => _database.SQLiteConnection;

        public Repository(Database database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }
        
        public IEnumerable<T> Get() => GetConnection().Table<T>();

        public  IEnumerable<T> Search(Expression<Func<T, bool>> predicate = null)
        {
            var query = GetConnection().Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }

        public T Get(int id) => GetConnection().Find<T>(id);

        public T Get(Expression<Func<T, bool>> predicate)
        {
            var result = GetConnection().Find(predicate);
            if (result == null)
                throw new EntityNotFoundException();
            else
                return result;
        } 

        public int Insert(T entity) => GetConnection().Insert(entity);

        public int Update(T entity) => GetConnection().Update(entity);

        public int Delete(T entity) => GetConnection().Delete(entity);
    }
}
