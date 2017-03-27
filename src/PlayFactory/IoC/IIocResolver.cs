using Autofac;

namespace PlayFactory.IoC
{
    public interface IIocResolver
    {
        IContainer Builder { get; }
    }
}
