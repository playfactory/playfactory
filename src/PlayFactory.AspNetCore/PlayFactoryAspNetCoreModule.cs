using Autofac;
using PlayFactory.IoC.Extensions;
using PlayFactory.Modules;
using PlayFactory.Reflection.Extensions;

namespace PlayFactory.AspNetCore
{
    public class PlayFactoryAspNetCoreModule : PlayFactoryModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterIoCAssemblyTypesByConvertion(this.GetExecutingAssembly());

            base.Load(builder);
        }       
    }
}
