using System;
using Videothek.Persistence;

namespace Videothek.Authentication
{
    public class DefaultAuthenticationStrategy : IAuthenticationStrategy
    {
        private readonly IQueryableDataProvider<Credentials> _dataProvider;

        public DefaultAuthenticationStrategy(IQueryableDataProvider<Credentials> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public AuthenticationToken VerifyCredentials(Credentials credentials)
        {
            return new AuthenticationToken(8329423, DateTime.Now);
        }
    }
}