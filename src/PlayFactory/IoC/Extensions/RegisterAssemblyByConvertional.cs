using System;
using System.Reflection;
using Autofac;
using Autofac.Core;
using PlayFactory.Events.Bus;
using PlayFactory.Events.Bus.Factories;
using PlayFactory.Events.Bus.Handlers;

namespace PlayFactory.IoC.Extensions
{
    /// <summary>
    /// Help for application modules to register IoC using the PlayFactory convention.
    /// </summary>
    public static class RegisterAssemblyByConvertional
    {
        /// <summary>
        /// Log all classes and interfaces in the IoC Container using the PlayFactory convention.
        /// </summary>
        /// <param name="container">Container of AutoFac</param>
        /// <param name="assemblyExecuting">Current module assembly</param>
        public static void RegisterIoCAssemblyTypesByConvertion(this ContainerBuilder container, Assembly assemblyExecuting)
        {
            Action<ComponentRegisteredEventArgs> onRegistered = (c) =>
            {

                var type = c.ComponentRegistration.Activator.LimitType;

                if (!typeof(IEventHandler).IsAssignableFrom(type))
                    return;

                var interfaces = type.GetInterfaces();
                
                foreach (var @interface in interfaces)
                {
                    if (!typeof(IEventHandler).IsAssignableFrom(@interface))
                        continue;

                    var genericArgs = @interface.GetGenericArguments();
                    if (genericArgs.Length == 1)
                    {
                        EventBus.Instance.Register(genericArgs[0], new IocHandlerFactory(IocResolver.Instance, type));
                    }
                }
            };

            container.RegisterAssemblyTypes(assemblyExecuting)
                .AssignableTo<IEventHandler>()
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope()
                .OnRegistered(onRegistered);

            container.RegisterAssemblyTypes(assemblyExecuting)
                .Where(t => !typeof(IEventHandler).IsAssignableFrom(t))
                .AssignableTo<IInstancePerLifetimeScopeDependency>()
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();

            container.RegisterAssemblyTypes(assemblyExecuting)
                .Where(t => !typeof(IEventHandler).IsAssignableFrom(t))
                .AssignableTo<IInstancePerDependency>()
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();

            container.RegisterAssemblyTypes(assemblyExecuting)
               .Where(t => !typeof(IEventHandler).IsAssignableFrom(t))
               .AssignableTo<ISingleInstanceDependency>()
               .AsImplementedInterfaces()
               .PropertiesAutowired()
               .SingleInstance();
        }
    }
}
