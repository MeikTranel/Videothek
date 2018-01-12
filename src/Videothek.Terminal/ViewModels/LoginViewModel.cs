using System;
using Stylet;
using System.Security;
using Videothek.Authentication;
using Videothek.Core.Authorization;

namespace Videothek.Terminal.ViewModels
{
    public class LoginViewModel : Screen,ICanRequestRootViewModelExchange
    {
        private readonly IWindowManager _windowManager;
        private readonly ISessionProvider _sessionProvider;

        public LoginViewModel(IWindowManager windowManager, ISessionProvider authenticationProvider)
        {
            _windowManager = windowManager ?? throw new ArgumentNullException(nameof(windowManager));
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
                    {
                        Session = session
                    }
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
