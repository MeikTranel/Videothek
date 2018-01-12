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
            User = user ?? throw new ArgumentNullException("Cannot construct session without user.");
            AuthenticationToken = authenticationToken ?? throw new ArgumentNullException("Cannot construct session without authenticationToken");
        }
    }
}