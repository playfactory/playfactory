using Autofac;
using PlayFactory.Modules;

namespace PlayFactory.Events.Bus
{
    /// <summary>
    /// EventBus module.
    /// </summary>
    public class EventBusModule : PlayFactoryModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => EventBus.Instance)
                .As<IEventBus>()
                .PropertiesAutowired()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
