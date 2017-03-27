using System;
using Autofac;
using PlayFactory.Extensions;

namespace PlayFactory.IoC
{
    /// <summary>
    /// Classe que gerencia o Container IoC do PlayFactory
    /// </summary>
    public static class ContainerIoC
    {
        private static ContainerBuilder _instance;
        private static IContainer _container;
        private static readonly object _containerLock = new object();

        /// <summary>
        /// Container IoC do PlayFactory.
        /// </summary>
        public static ContainerBuilder Container => _instance ?? (_instance = new ContainerBuilder());

        /// <summary>
        /// Builder do Container IoC.
        /// </summary>
        public static IContainer Builder {
            get
            {
                return _containerLock.Locking(() => _container);
            }
            private set { _container = value; }
        }

        /// <summary>
        /// Método que define o Builder do Container através de um scope.
        /// </summary>
        /// <param name="action">Action que apartir de um Container gere um Builder.</param>
        /// <returns>Retorna um Builder do Container</returns>
        public static IContainer ScopeContainer(Func<ContainerBuilder, IContainer> action)
        {
            Builder = action?.Invoke(Container);
            return Builder;
        }
    }
}
