using Castle.DynamicProxy;
using Polly;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnionMessenger.WebApi.Infrastructure.Interceptors
{
    public class PollyInterceptor : IInterceptor
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public void Intercept(IInvocation invocation)
        {
            Policy
                .Handle<SqlException>()
                .WaitAndRetry(new[]
                {
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(7),
                    TimeSpan.FromSeconds(15)
                }, (ex, timespan, retryCount, context) =>
                {
                    _logger.Error(ex, $"Error - {invocation.TargetType.Name}.{invocation.Method.Name} - try retry (count: {retryCount})");
                })
                .Execute(() => invocation.Proceed());            
        }
    }
}