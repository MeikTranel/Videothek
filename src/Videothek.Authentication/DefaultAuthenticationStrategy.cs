using System;

namespace Videothek.Authentication
{
    public class DefaultAuthenticationStrategy : IAuthenticationStrategy
    {
        public AuthenticationToken VerifyCredentials(Credentials credentials)
        {
            return new AuthenticationToken(8329423, DateTime.Now);
        }
    }
}