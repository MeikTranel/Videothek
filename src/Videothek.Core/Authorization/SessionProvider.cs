using System;
using System.Security;
using Videothek.Authentication;

namespace Videothek.Core.Authorization
{
    public class SessionProvider: ISessionProvider
    {
        private readonly UserService _userService;
        private readonly IAuthenticationStrategy _authenticationStrategy;

        public SessionProvider(UserService userService,IAuthenticationStrategy authenticationStrategy)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
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
            var userExists = _userService.TryGetUser(userName, out var user);
            if (!userExists)
                throw new AuthenticationFailedException($"Could not resolve UserName: {userName}");

            return user;
        }
    }
}