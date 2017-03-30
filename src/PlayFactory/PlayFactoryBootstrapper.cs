using Autofac;
using PlayFactory.Common;
using PlayFactory.IoC;
using PlayFactory.Modules;

namespace PlayFactory
{
    /// <summary>
    /// Bootstrap class from PlayFactory.
    /// </summary>
    public class PlayFactoryBootstrapper
    {
        /// <summary>Gets IocResolver object used by this class.</summary>
        public IIocResolver IocResolver { get; }

        private PlayFactoryBootstrapper(IIocResolver iocResolver)
        {
            Check.NotNull(iocResolver, "iocResolver");

            IocResolver = iocResolver;
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
    }
}
