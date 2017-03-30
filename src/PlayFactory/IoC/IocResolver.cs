using System;
using Autofac;

namespace PlayFactory.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public class IocResolver : IIocResolver
    {
        private static IocResolver _iocResolver;

        public static IocResolver Instance => _iocResolver ?? (_iocResolver = new IocResolver(new ContainerBuilder()));

        public IContainer Builder { get; private set; }
        public ContainerBuilder ContainerBuilder { get; }

      

        public IocResolver(ContainerBuilder containerBuilder)
        {
            ContainerBuilder = containerBuilder;
        }

        public void UpdateContainer(Action<ContainerBuilder> actionUpdate)
        {
            UpdateContainer((builder, container) => actionUpdate(container));
        }

        public IContainer Build()
        {
            Builder = ContainerBuilder.Build();
            return Builder;
        }

        public void UpdateContainer(Action<IContainer, ContainerBuilder> actionUpdate)
        {
            var container = new ContainerBuilder();

            actionUpdate?.Invoke(Builder, container);

            container.Update(Builder);
        }
    }
}
