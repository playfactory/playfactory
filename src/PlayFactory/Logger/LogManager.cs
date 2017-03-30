using System;
using Autofac;
using Microsoft.Extensions.Logging;
using PlayFactory.IoC;

namespace PlayFactory.Logger
{
    /// <summary>
    /// Class responsible for managing and creating Logger instances.
    /// </summary>
    public static class LogManager
    {
        /// <summary>
        /// Creates an ILogger instance by setting the type passed as parameter as the category of the Logger.
        /// </summary>
        /// <param name="instanceType">Type that will use the Logger.</param>
        /// <returns>Returns a ILogger.</returns>
        public static ILogger GetLogger(Type instanceType)
        {
            var loggerFactory = IocResolver.Instance.Builder.Resolve<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(instanceType);

            return logger;
        }
    }
}
