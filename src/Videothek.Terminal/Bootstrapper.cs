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
    public class Bootstrapper : Bootstrapper<HostViewModel>
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

    }
}
