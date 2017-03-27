using System;
using Autofac;
using PlayFactory.Events.Bus.Handlers;
using PlayFactory.IoC;


namespace PlayFactory.Events.Bus.Factories
{
    /// <summary>
    /// This <see cref="IEventHandlerFactory"/> implementation is used to get/release
    /// handlers using Ioc.
    /// </summary>
    public class IocHandlerFactory : IEventHandlerFactory
    {
        /// <summary>
        /// Type of the handler.
        /// </summary>
        public Type HandlerType { get; }

        private readonly IIocResolver _iocResolver;

        /// <summary>
        /// Creates a new instance of <see cref="IocHandlerFactory"/> class.
        /// </summary>
        /// <param name="iocResolver"></param>
        /// <param name="handlerType">Type of the handler</param>
        public IocHandlerFactory(IIocResolver iocResolver, Type handlerType)
        {
            _iocResolver = iocResolver;
            HandlerType = handlerType;
        }

        /// <summary>
        /// Resolves handler object from Ioc container.
        /// </summary>
        /// <returns>Resolved handler object</returns>
        public IEventHandler GetHandler()
        {
            return (IEventHandler)_iocResolver.Builder.Resolve(HandlerType);
        }
    }
}