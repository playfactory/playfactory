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
    /// Help para os módulos de aplicação registrar o IoC utilizando a convenção do PlayFactory.
    /// </summary>
    public static class RegisterAssemblyByConvertional
    {
        /// <summary>
        /// Registra no Container IoC as interfaces e classes que são padrões no PlayFactory
        /// </summary>
        /// <param name="container">Container do AutoFac</param>
        /// <param name="assemblyExecuting">Assembly atual do módulo</param>
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
                .InstancePerLifetimeScope();

            container.RegisterAssemblyTypes(assemblyExecuting)
                .Where(t => !typeof(IEventHandler).IsAssignableFrom(t))
                .AssignableTo<IInstancePerDependency>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            container.RegisterAssemblyTypes(assemblyExecuting)
               .Where(t => !typeof(IEventHandler).IsAssignableFrom(t))
               .AssignableTo<ISingleInstanceDependency>()
               .AsImplementedInterfaces()
               .SingleInstance();
        }
    }
}
