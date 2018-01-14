using Stylet;
using StyletIoC;
using Videothek.Authentication;
using Videothek.Core;
using Videothek.Core.Authorization;
using Videothek.Core.Configuration;
using Videothek.Persistence;
using Videothek.Terminal.ViewModels;

namespace Videothek.Terminal
{
    public class Bootstrapper : Bootstrapper<LoginViewModel>
    {
    
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            builder.Bind<IAuthenticationStrategy>()
                .To<DefaultAuthenticationStrategy>()
                .InSingletonScope();

            builder.Bind<IQueryableDataProvider<User>>()
                .To<LazyUserDataProvider>()
                .InSingletonScope();

            builder.Bind<IQueryableDataProvider<Credentials>>()
                .To<LazyCredentialDataProvider>()
                .InSingletonScope();

            builder.Bind<IRepository<User>>()
                .To<UserRepository>();

            builder.Bind<ISessionProvider>()
                .To<SessionProvider>()
                .InSingletonScope();
        }

        protected override void DisplayRootView(object rootViewModel)
        {
            if (rootViewModel is ICanRequestRootViewModelExchange interchangeableRootVM)
                HandleInterchangeableRootVM(interchangeableRootVM);

            base.DisplayRootView(rootViewModel);
        }

        private void HandleInterchangeableRootVM(ICanRequestRootViewModelExchange interchangeableRootVM)
        {
            if (RootViewModel is ICanRequestRootViewModelExchange interchangeableCurrentRootVM)
                interchangeableCurrentRootVM.RootVMExchangeRequested -= HandleRootVMExchangeRequested;

            interchangeableRootVM.RootVMExchangeRequested += HandleRootVMExchangeRequested;
        }

        private void HandleRootVMExchangeRequested(object sender, object e)
        {
            var windowToBeClosed = GetActiveWindow();
            DisplayRootView(e);
            windowToBeClosed.Close();
        }
    }
}
