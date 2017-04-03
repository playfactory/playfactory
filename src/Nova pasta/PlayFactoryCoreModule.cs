using Autofac;
using PlayFactory.IoC.Extensions;
using PlayFactory.Modules;
using PlayFactory.Reflection.Extensions;

namespace PlayFactory.Core
{
    public class PlayFactoryCoreModule : PlayFactoryModule 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterIoCAssemblyTypesByConvertion(this.GetExecutingAssembly());
        }
    }
}
