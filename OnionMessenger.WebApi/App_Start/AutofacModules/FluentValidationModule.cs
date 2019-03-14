using Autofac;
using System.Linq;
using FluentValidation;
using FluentValidation.WebApi;
using OnionMessenger.WebApi.Validators;
using System.Web.Http.Validation;

namespace OnionMessenger.WebApi.App_Start.AutofacModules
{
    public class FluentValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(WebApiApplication).Assembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<FluentValidationModelValidatorProvider>().As<ModelValidatorProvider>();

            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();

        }
    }
}