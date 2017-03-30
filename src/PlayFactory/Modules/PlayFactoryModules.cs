using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PlayFactory.IoC;
using PlayFactory.Reflection;

namespace PlayFactory.Modules
{
    /// <summary>
    /// Class that manages the PlayFactory modules
    /// </summary>
    public class PlayFactoryModules : IPlayFactoryModules, ISingleInstanceDependency
    {
        public ILogger Logger { get; set; }

        /// <inheritdoc />
        public List<IPlayFactoryModule> Modules { get; }

        public PlayFactoryModules()
        {
            Logger = NullLogger.Instance;
            Modules = new List<IPlayFactoryModule>();
        }

        /// <inheritdoc />
        public void Add(IPlayFactoryModule module)
        {
            Modules.Add(module);
        }

        /// <inheritdoc />
        public void Add(IEnumerable<IPlayFactoryModule> modules)
        {
            Modules.AddRange(modules);
        }

        /// <inheritdoc />
        /// </summary>
        public void LoadModules()
        {
            var type = typeof(PlayFactoryModule);
            Logger.LogInformation("Initiating loading of the modules.");
            try
            {
                AppDomain.GetAssemblies(assembly =>
                {
                    var modules = assembly.GetTypes().Where(t => t != type && typeof(PlayFactoryModule).IsAssignableFrom(t))
                        .Select(t => (IPlayFactoryModule)Activator.CreateInstance(t));

                    var modulesAutoLoad = modules.Where(m => m.AutoLoad());

                    Add(modulesAutoLoad);
                });
            }
            catch (Exception e)
            {
                Logger.LogError("The following error occurred while loading the module: ", e.Message);               
                throw;
            }

            Logger.LogInformation("{0} modules loaded.", Modules.Count);
        }

        /// <inheritdoc />
        public void Initialize(ContainerBuilder container)
        {
            try
            {
                Logger.LogInformation("Initiating the registration of Modules in the IoC Container.");
                foreach (var module in Modules)
                {
                    Logger.LogDebug("Registering the {0} module in PlayFactoryModules.", module.GetType().FullName);
                    container.RegisterModule(module);
                }
                Logger.LogInformation("{0} modules registered.", Modules.Count);
            }
            catch (Exception e)
            {
                Logger.LogError("The following error occurred while register the module: ", e.Message);
                throw;
            }
        }
    }
}
