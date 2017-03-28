using Autofac;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PlayFactory.Common;
using PlayFactory.IoC;
using PlayFactory.Modules;

namespace PlayFactory
{
    public class PlayFactoryBootstrapper
    {
        private ILogger _logger;

        /// <summary>Gets IocResolver object used by this class.</summary>
        public IIocResolver IocResolver { get; }

        private PlayFactoryBootstrapper(IIocResolver iocResolver)
        {
            Check.NotNull(iocResolver, "iocResolver");

            IocResolver = iocResolver;
            _logger = NullLogger.Instance;
        }

        public static PlayFactoryBootstrapper Create(IIocResolver iocResolver)
        {
            return new PlayFactoryBootstrapper(iocResolver);
        }

        public void Initialize()
        {
            IocResolver.UpdateContainer(container =>
            {
                RegisterBootstrapper(container);
                container.RegisterModule<PlayFactoryBaseModule>();
            });

            RegisterModules();
            
        }

        private void RegisterBootstrapper(ContainerBuilder container)
        {
            if (IocResolver.Builder.IsRegistered(typeof(PlayFactoryBootstrapper)))
                return;

            container.Register(c => this)
                   .AsSelf()
                   .SingleInstance();
        }

        private void RegisterModules()
        {
            IocResolver.UpdateContainer((builder, container) =>
            {
                var moduleManager = builder.Resolve<IPlayFactoryModules>();
                moduleManager.LoadModules();
                moduleManager.Initialize(container);
            });
        }

        private void RegisterLogger()
        {
            //var logger = loggerFactory.CreateLogger("PlayFactory");
            //logger.LogInformation("Teste Information");
        }
    }
}
