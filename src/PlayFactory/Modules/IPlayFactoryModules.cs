using System.Collections.Generic;
using Autofac;

namespace PlayFactory.Modules
{
    public interface IPlayFactoryModules
    {
        List<IPlayFactoryModule> Modules { get; }
        void Add(IEnumerable<IPlayFactoryModule> modules);
        void Add(IPlayFactoryModule module);
        void Initialize(ContainerBuilder container);
        void LoadModules();
    }
}