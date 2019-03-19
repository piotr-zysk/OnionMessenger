using Autofac;
using OnionMessenger.WebApi.Infrastructure.Interceptors;


namespace AutofacInterceptors.App_Start.AutofacModules
{
    public class InterceptorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogInterceptor>()
                .SingleInstance();

            
            builder.RegisterType<PollyInterceptor>()
                .SingleInstance();

            /*
            builder.RegisterType<CacheInterceptor>()
                .SingleInstance();

            builder.RegisterType<CacheService>()
                .AsImplementedInterfaces()
                .SingleInstance();
            */
        }
    }
}