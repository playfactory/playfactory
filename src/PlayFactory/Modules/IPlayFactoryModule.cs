using Autofac.Core;

namespace PlayFactory.Modules
{
    /// <summary>
    /// This interface must be implemented by all application modules to identify them by convention.
    /// </summary>
    public interface IPlayFactoryModule : IModule
    {
        /// <summary>
        /// Determines whether or not the module should load automatically.
        /// </summary>
        /// <returns>If the result is true p module will be loaded automatically.</returns>
        bool AutoLoad();
    }
}
