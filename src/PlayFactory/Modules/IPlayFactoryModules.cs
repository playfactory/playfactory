using System.Collections.Generic;
using Autofac;

namespace PlayFactory.Modules
{
    /// <summary>
    /// Interface used by the module manager.
    /// </summary>
    public interface IPlayFactoryModules
    {
        /// <summary>
        /// List of modules added to the application.
        /// </summary>
        List<IPlayFactoryModule> Modules { get; }
        /// <summary>
        /// Method for adding a list of modules to the application.
        /// </summary>
        /// <param name="modules">List of modules.</param>
        void Add(IEnumerable<IPlayFactoryModule> modules);
        /// <summary>
        ///Method to add a module to the application.
        /// </summary>
        /// <param name="module">Module</param>
        void Add(IPlayFactoryModule module);
        /// <summary>
        /// Method used to initialize the modules.
        /// </summary>
        /// <remarks>It should be used internally</remarks>
        /// <param name="container">IoC Resolver</param>
        void Initialize(ContainerBuilder container);
        /// <summary>
        /// Method used to load all modules.
        /// </summary>
        /// <remarks>It should be used internally.</remarks>
        void LoadModules();
    }
}