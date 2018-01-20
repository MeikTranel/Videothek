using System;
using Stylet;
using System.Security;
using Videothek.Authentication;
using Videothek.Core.Authorization;

namespace Videothek.Terminal.ViewModels
{
    public class LoginViewModel : Screen,ICanRequestRootViewModelExchange
    {
        private readonly ISessionProvider _sessionProvider;

        public LoginViewModel(ISessionProvider authenticationProvider)
        {
            _sessionProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));

            this.DisplayName = "Login";
        }

        public string Username { get; set; }
        public SecureString Password { get; set; }

        public event EventHandler<object> RootVMExchangeRequested;

        public void DoLogin()
        {
            try
            {
                var session = _sessionProvider.RequestSession(Username,Password);

                RequestVMExchange(
                    new MainViewModel()
                );
            }
            catch (AuthenticationFailedException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void RequestVMExchange(object screen)
        {
            RootVMExchangeRequested?.Invoke(this, screen);
        }
    }
}
