using Autofac;
using PlayFactory.EntityFrameworkCore.Repository;
using PlayFactory.IoC.Extensions;
using PlayFactory.Modules;
using PlayFactory.Reflection.Extensions;
using PlayFactory.Repository;

namespace PlayFactory.EntityFrameworkCore
{
    public class PlayFactoryEntityModule : PlayFactoryModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterIoCAssemblyTypesByConvertion(this.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(RepositoryOfEntity<>))
               .As(typeof(IRepository<>))
               .InstancePerDependency();

            builder.RegisterGeneric(typeof(RepositoryOfEntityWithPrimaryKey<,>))
                .As(typeof(IRepository<,>))
                .InstancePerDependency();

            builder.RegisterGeneric(typeof(RepositoryBase<>))
                .As(typeof(IRepositoryBase<>))
                .InstancePerDependency();

            base.Load(builder);
        }

        public override bool AutoLoad()
        {
            return false;
        }
    }
}
