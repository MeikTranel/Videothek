using AutoMapper;
using Stylet;
using StyletIoC;
using Videothek.Authentication;
using Videothek.Core;
using Videothek.Core.Authorization;
using Videothek.Core.Mapping;
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

            builder.Bind<ISessionProvider>()
                .To<SessionProvider>()
                .InSingletonScope();

            builder.Bind<ILocalDBStorageLocationStrategy>()
                .ToInstance(
                    new PortableLocalDBStorageLocationStrategy("Videothek.Production.sqlite")
                );

            builder.Bind<Database>()
                .ToSelf()
                .InSingletonScope();

            builder.Bind(typeof(Repository<>))
                .ToSelf();


            //User Level Services
            builder.Bind<UserService>()
                .ToSelf();
            builder.Bind<VideoService>()
                .ToSelf();
        }

        protected override void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EntityToBusinessObjectConfiguration>();
                cfg.ConstructServicesUsing(t => Container.Get(t));
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
