using Autofac;
using PlayFactory.Modules;

namespace PlayFactory.Events.Bus
{
    public class EventBusModule : PlayFactoryModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c) =>  EventBus.Instance).As<IEventBus>()
                .SingleInstance();


            base.Load(builder);
        }

        
    }
}
