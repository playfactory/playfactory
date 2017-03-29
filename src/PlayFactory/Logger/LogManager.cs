using System;
using Autofac;
using Microsoft.Extensions.Logging;
using PlayFactory.IoC;

namespace PlayFactory.Logger
{
    public static class LogManager
    {
        public static ILogger GetLogger(Type instanceType)
        {
            var loggerFactory = IocResolver.Instance.Builder.Resolve<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(instanceType);

            return logger;
        }
    }
}
