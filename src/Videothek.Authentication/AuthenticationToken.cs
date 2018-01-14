using System;

namespace Videothek.Authentication
{
    public class AuthenticationToken
    {
        public AuthenticationToken(int publicKey, DateTime lastRefresh)
        {
            if (publicKey == default(int))
                throw new ArgumentNullException(nameof(publicKey));
            PublicKey = publicKey;

            if (publicKey == default(int))
                throw new ArgumentNullException(nameof(lastRefresh));
            LastRefresh = lastRefresh;
        }

        public int PublicKey { get; }
        public DateTime LastRefresh { get; }
    }
}