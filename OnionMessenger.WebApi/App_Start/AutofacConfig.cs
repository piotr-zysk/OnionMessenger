using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using SimpleHashing.Net;

namespace OnionMessenger.WebApi.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(AutofacConfig).Assembly);

            builder.RegisterType<SimpleHash>().AsImplementedInterfaces();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}