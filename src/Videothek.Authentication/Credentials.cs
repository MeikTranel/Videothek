using System.Security;

namespace Videothek.Authentication
{
    public class Credentials
    {
        public int Identity { get; }
        public SecureString Password { get; }

        public Credentials(int identity, SecureString password)
        {
            Identity = identity;
            Password = password;
        }
    }
}