using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Microsoft.Extensions.Logging;
using PlayFactory.IoC;
using PlayFactory.IoC.Extensions;
using PlayFactory.Logger;
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

        private static void InjectLoggerProperties(object instance)
        {
            var instanceType = instance.GetType();

            if (!(instance is IResolveIoCInstance))
                return;

            // Get all the injectable properties to set.
            // If you wanted to ensure the properties were only UNSET properties,
            // here's where you'd do it.
            var properties = instanceType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(ILogger) && p.CanWrite && p.GetIndexParameters().Length == 0);

            // Set the properties located.
            foreach (var propToSet in properties)
            {
                propToSet.SetValue(instance, LogManager.GetLogger(instanceType), null);
            }
        }



        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
            IComponentRegistration registration)
        {

            // Handle properties.
            registration.Activated += (sender, e) => InjectLoggerProperties(e.Instance);
        }
    }
}
