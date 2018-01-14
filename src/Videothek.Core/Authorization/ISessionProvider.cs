using System.Security;

namespace Videothek.Core.Authorization
{
    public interface ISessionProvider
    {
        Session RequestSession(string username,SecureString password);
    }
}