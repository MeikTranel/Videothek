using System;
using System.Security;
using Videothek.Authentication;
using Videothek.Persistence;

namespace Videothek.Core.Authorization
{
    public class SessionProvider: ISessionProvider
    {
        private readonly IRepository<User> _userRepository;
        private readonly IAuthenticationStrategy _authenticationStrategy;

        public SessionProvider(IRepository<User> userRepository,IAuthenticationStrategy authenticationStrategy)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _authenticationStrategy = authenticationStrategy ?? throw new ArgumentNullException(nameof(authenticationStrategy));
        }

        public Session RequestSession(string userName, SecureString password)
        {
            var user = ResolveUserName(userName);
            return new Session(
                user,
                GenerateAuthenticationToken(user, password)
            );
        }

        private AuthenticationToken GenerateAuthenticationToken(User user, SecureString password)
        {
            return _authenticationStrategy.VerifyCredentials(
                    new Credentials(user.ID,password)
                );
        }

        private User ResolveUserName(string userName)
        {
            try
            {
                return _userRepository.Get(userName);
            }
            catch (EntityNotFoundException<User>)
            {
                throw new AuthenticationFailedException($"Could not resolve UserName: {userName}");
            }
        }
    }
}