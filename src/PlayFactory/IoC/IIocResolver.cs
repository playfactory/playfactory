using System;
using Autofac;

namespace PlayFactory.IoC
{
    /// <summary>
    /// PlayFactory container manager interface. This inteface should be used to register and resolve dependency.
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// Property used to resolve dependencies.
        /// </summary>
        IContainer Builder { get; }
        /// <summary>
        /// Property used to register dependencies.
        /// </summary>
        /// <remarks>
        /// It is not recommended to use this property to register dependency outside PlayFactoryModule, 
        /// as it will not be registered in the Container IoC. To register a type outside the module it is 
        /// recommended to use the action.
        /// </remarks>
        ContainerBuilder ContainerBuilder { get; }
        /// <summary>
        /// Action used to register types in Container IoC. This method should only be used outside the PlayFactoryModule.
        /// </summary>
        /// <param name="actionUpdate">Action to register types in Container. The Container IoC responsible for the registry will be passed as parameter.</param>
        void UpdateContainer(Action<ContainerBuilder> actionUpdate);
        /// <summary>
        /// Action used to register types in Container IoC. This method should only be used outside the PlayFcatoryModule.
        /// </summary>
        /// <param name="actionUpdate">Action to register types in Container. The first parameter will be the Builder, which is responsible for resolving the dependencies, and second parameter will be the IoC Container responsible for registering the dependencies.</param>
        void UpdateContainer(Action<IContainer, ContainerBuilder> actionUpdate);
    }
}
