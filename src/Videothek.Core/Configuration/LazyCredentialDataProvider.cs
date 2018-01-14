using System.Collections.Generic;
using Videothek.Authentication;
using Videothek.Persistence;

namespace Videothek.Core.Configuration
{
    public class LazyCredentialDataProvider : IQueryableDataProvider<Credentials>
    {
        public LazyCredentialDataProvider()
        {
            var entities = new List<Credentials>(new[]{
                new Credentials(1,"memes".ToSecureString()),
                new Credentials(2,"admin".ToSecureString())
            });
            Entities = entities;
        }

        public IEnumerable<Credentials> Entities { get; }
    }
}