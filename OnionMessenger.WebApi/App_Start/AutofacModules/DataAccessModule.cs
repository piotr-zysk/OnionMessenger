using Autofac;
using Autofac.Extras.DynamicProxy;
using OnionMessenger.WebApi.Infrastructure.Interceptors;
using OnionMessenger.DataAccess.DB;
using OnionMessenger.DataAccess.Repositories;

using System.Linq;

namespace OnionMessenger.WebApi.App_Start.AutofacModules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OMDBContext>()
                //.OnActivated(d => d.Instance.UserName = HttpContext.Current?.User?.Identity?.Name)
                //.InstancePerRequest();
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(MessageRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()   // enable interceptor for those particular types
                .InterceptedBy(typeof(LogInterceptor))
                .InterceptedBy(typeof(PollyInterceptor))
                .InstancePerLifetimeScope(); 
                //.InstancePerRequest();  // connect interceptor
                
        }
    }
}