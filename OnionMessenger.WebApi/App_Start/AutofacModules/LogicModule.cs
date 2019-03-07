using Autofac;
using Autofac.Extras.DynamicProxy;
using OnionMessenger.WebApi.Infrastructure.Interceptors;
using OnionMessenger.Logic;


using System.Linq;

namespace OnionMessenger.WebApi.App_Start.AutofacModules
{
    public class LogicsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(UserLogic).Assembly)
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()   // enable interceptor for those particular types
                .InterceptedBy(typeof(LogInterceptor));  // connect interceptor
                //.InterceptedBy(typeof(PollyInterceptor));
        }
    }
}