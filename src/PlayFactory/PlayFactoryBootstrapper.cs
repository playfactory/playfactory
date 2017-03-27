using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PlayFactory.Common;
using PlayFactory.IoC;

namespace PlayFactory
{
    public class PlayFactoryBootstrapper
    {
        private ILogger _logger;

        /// <summary>
        /// Get the startup module of the application which depends on other used modules.
        /// </summary>
        public Type StartupModule { get; }

        /// <summary>Gets IocResolver object used by this class.</summary>
        public IocResolver IocResolver { get; }

        private PlayFactoryBootstrapper(Type startupModule, IocResolver iocResolver)
        {
            Check.NotNull(startupModule, "startupModule");
            Check.NotNull(iocResolver, "iocResolver");

            if (!typeof(PlayFactoryBaseModule).IsAssignableFrom(startupModule))
                throw new ArgumentException(string.Format("{0} should be derived from {1}.", "startupModule", "PlayFactoryModule"));

            StartupModule = startupModule;
            IocResolver = iocResolver;
            _logger = NullLogger.Instance;
        }

        public static PlayFactoryBootstrapper Create(Type startupModule, IocResolver iocResolver)
        {
            return new PlayFactoryBootstrapper(startupModule, iocResolver);
        }

        public static PlayFactoryBootstrapper Create<TStartupModule>(IocResolver iocResolver) where TStartupModule : PlayFactoryBaseModule
        {
            return new PlayFactoryBootstrapper(typeof(TStartupModule), iocResolver);
        }

        private void RegisterBootstrapper()
        {
            
        }
    }
}
