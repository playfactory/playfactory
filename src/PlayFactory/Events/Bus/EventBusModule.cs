using Autofac;
using PlayFactory.Modules;

namespace PlayFactory.Events.Bus
{
    public class EventBusModule : PlayFactoryModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventBus>()
                .As<IEventBus>()
                .PropertiesAutowired()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
