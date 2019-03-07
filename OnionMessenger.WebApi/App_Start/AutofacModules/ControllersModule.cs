using Autofac;
using Autofac.Integration.WebApi;

namespace AutofacInterceptors.App_Start.AutofacModules
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register your MVC controllers. (ControllersModule is the name of
            // the class in Global.asax.)
            builder.RegisterApiControllers(typeof(ControllersModule).Assembly);
        }
    }
}