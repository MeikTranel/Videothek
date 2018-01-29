using System.Security;

namespace Videothek.Core.Authorization
{
    public interface ISessionProvider
    {
        bool TryGetActiveSession(out Session session);
        void CreateSession(string username,SecureString password);
    }
}