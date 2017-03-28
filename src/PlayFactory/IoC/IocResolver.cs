using System;
using Autofac;

namespace PlayFactory.IoC
{
    public class IocResolver : IIocResolver
    {

        public static IocResolver Instance  => new IocResolver(new ContainerBuilder());
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
