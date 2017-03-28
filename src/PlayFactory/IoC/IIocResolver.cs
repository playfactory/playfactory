using System;
using Autofac;

namespace PlayFactory.IoC
{
    public interface IIocResolver
    {
        IContainer Builder { get; }
        ContainerBuilder ContainerBuilder { get; }
        void UpdateContainer(Action<ContainerBuilder> actionUpdate);
        void UpdateContainer(Action<IContainer, ContainerBuilder> actionUpdate);
    }
}
