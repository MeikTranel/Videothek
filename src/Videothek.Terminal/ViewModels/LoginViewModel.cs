using System;
using Stylet;
using System.Security;
using Videothek.Authentication;
using Videothek.Core.Authorization;

namespace Videothek.Terminal.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly ISessionProvider _sessionProvider;

        public LoginViewModel(ISessionProvider authenticationProvider)
        {
            _sessionProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));

            this.DisplayName = "Login";
        }

        public string Username { get; set; }
        public SecureString Password { get; set; }
        

        public void DoLogin()
        {
            try
            {
                var session = _sessionProvider.RequestSession(Username,Password);

                LoginSucceeded?.Invoke(this, session);
            }
            catch (AuthenticationFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public event EventHandler<Session> LoginSucceeded;

    }
}
