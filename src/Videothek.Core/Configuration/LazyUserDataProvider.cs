using System.Collections.Generic;
using Videothek.Persistence;

namespace Videothek.Core.Configuration
{
    public class LazyUserDataProvider : IQueryableDataProvider<User>
    {
        public LazyUserDataProvider()
        {
            var entities = new List<User>(new User[]{
                new User(1,"Meik"),
                new User(2,"Admin")
            });
            Entities = entities;
        }

        public IEnumerable<User> Entities { get; }
    }
}
