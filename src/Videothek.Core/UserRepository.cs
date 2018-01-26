using System;
using System.Collections.Generic;
using System.Linq;
using Videothek.Persistence;

namespace Videothek.Core
{
    public class UserRepository : IRepository<User>
    {
        private readonly IQueryableDataProvider<User> _userDataProvider;

        public UserRepository(IQueryableDataProvider<User> userDataProvider)
        {
            _userDataProvider = userDataProvider ?? throw new ArgumentNullException(nameof(userDataProvider));
        }

        public User Get(string key)
        {
            try
            {
                return _userDataProvider
                    .Entities
                    .First(user => user.Name == key);
            }
            catch (InvalidOperationException)
            {
                throw new EntityNotFoundException<User>();
            }
        }

        public IEnumerable<User> Fetch()
        {
            return _userDataProvider.Entities;
        }
    }
}