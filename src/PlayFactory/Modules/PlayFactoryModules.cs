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
    /// Classe que gerencia os módulos do PlayFactory
    /// </summary>
    public class PlayFactoryModules : IPlayFactoryModules, ISingleInstanceDependency
    {
        public ILogger Logger { get; set; }

        /// <summary>
        /// Lista dos módulos adicionados na aplicação.
        /// </summary>
        public List<IPlayFactoryModule> Modules { get; }

        public PlayFactoryModules()
        {
            Logger = NullLogger.Instance;
            Modules = new List<IPlayFactoryModule>();
        }

        /// <summary>
        /// Método para adicionar um módulo para aplicação
        /// </summary>
        /// <param name="module">Módulo que será adicionado a aplicação</param>
        public void Add(IPlayFactoryModule module)
        {
            Modules.Add(module);
        }

        /// <summary>
        /// Método para adicionar uma lista de módulos para aplicação
        /// </summary>
        /// <param name="modules">Módulos que serão adicionados a aplicação</param>
        public void Add(IEnumerable<IPlayFactoryModule> modules)
        {
            Modules.AddRange(modules);
        }

        /// <summary>
        /// Método que carrega todos os módulos da solutions e adiciona a aplicação
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

        /// <summary>
        /// Método que inicializa o gerenciado de módulos.  
        /// </summary>
        /// <remarks>Este método desencadeará a inicialização de todos os módulos adicionados a aplicação.</remarks>
        /// <param name="container">ContainerIoC que será utilizado pelos módulos.</param>
        public void Initialize(ContainerBuilder container)
        {
            try
            {
                Logger.LogInformation("Initiating the registration of Modules in the IoC Container.");
                foreach (var module in Modules)
                {
                    Logger.LogInformation("Registrando o módulo {0}.", module.GetType().FullName);
                    container.RegisterModule(module);
                }
                Logger.LogInformation("Initiating the registration of Modules in the IoC Container.");
            }
            catch (Exception e)
            {
                Logger.LogError("The following error occurred while register the module: ", e.Message);
                throw;
            }
        }
    }
}
