
using Castle.DynamicProxy;
using NLog;

namespace OnionMessenger.WebApi.Infrastructure.Interceptors
{
    public class LogInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Intercept(IInvocation invocation)
        {
            // https://github.com/nlog/nlog/wiki/Tutorial
            logger.Info($"Calling: {invocation.TargetType.Name}.{invocation.Method.Name}");

            invocation.Proceed();

            //logger.Info($"After call: {invocation.TargetType.Name}.{invocation.Method.Name}");
        }
    }
}