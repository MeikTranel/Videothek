using System;
using Videothek.Authentication;

namespace Videothek.Core.Authorization
{
    public class Session
    {
        public User User { get; }
        public AuthenticationToken AuthenticationToken { get; }

        public Session(User user,AuthenticationToken authenticationToken)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            AuthenticationToken = authenticationToken ?? throw new ArgumentNullException(nameof(authenticationToken));
        }
    }
}