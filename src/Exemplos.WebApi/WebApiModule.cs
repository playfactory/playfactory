using Autofac;
using PlayFactory.IoC.Extensions;
using PlayFactory.Modules;
using PlayFactory.Reflection.Extensions;

namespace Exemplos.WebApi
{
    public class WebApiModule : PlayFactoryModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterIoCAssemblyTypesByConvertion(this.GetExecutingAssembly());
        }
    }
}
