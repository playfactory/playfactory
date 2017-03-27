using Autofac;
using PlayFactory.IoC.Extensions;
using PlayFactory.Modules;
using PlayFactory.Reflection.Extensions;

namespace PlayFactory
{
    public class PlayFactoryBaseModule : PlayFactoryModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterIoCAssemblyTypesByConvertion(this.GetExecutingAssembly());

            base.Load(builder);
        }

        public override bool AutoLoad()
        {
            return false;
        }
    }
}
