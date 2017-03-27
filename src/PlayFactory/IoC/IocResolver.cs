using Autofac;

namespace PlayFactory.IoC
{
    public class IocResolver : IIocResolver, ISingleInstanceDependency
    {
        public IContainer Builder => ContainerIoC.Builder;
    }
}
