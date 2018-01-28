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

            DisplayName = "Login";
        }

        public string Username { get; set; }
        public SecureString Password { get; set; }
        

        public void DoLogin()
        {
            try
            {
                _sessionProvider.CreateSession(Username,Password);

                OnLoginSucceeded();
            }
            catch (AuthenticationFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public event EventHandler LoginSucceeded;

        protected virtual void OnLoginSucceeded()
        {
            LoginSucceeded?.Invoke(this,null);
        }
    }
}
