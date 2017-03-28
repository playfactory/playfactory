using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using PlayFactory.IoC;
using PlayFactory.Reflection;

namespace PlayFactory.Modules
{
    /// <summary>
    /// Classe que gerencia os módulos do PlayFactory
    /// </summary>
    public class PlayFactoryModules : IPlayFactoryModules, ISingleInstanceDependency
    {
        /// <summary>
        /// Lista dos módulos adicionados na aplicação.
        /// </summary>
        public List<IPlayFactoryModule> Modules { get; }

        public PlayFactoryModules()
        {
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
            //var type = typeof(PlayFactoryModule);

            //var deps = DependencyContext.Default.RuntimeLibraries;

            //foreach (var compilationLibrary in deps)
            //{
            //    var assembly = Assembly.Load(new AssemblyName(compilationLibrary.Name));

            //    var modules = assembly.GetTypes().Where(t => t != type && type.IsAssignableFrom(t))
            //                    .Select(t => (IPlayFactoryModule)Activator.CreateInstance(t));

            //    var modulesAutoLoad = modules.Where(m => m.AutoLoad());

            //    Add(modulesAutoLoad);
            //}

            var type = typeof(PlayFactoryModule);

            AppDomain.GetAssemblies(assembly =>
            {
                var modules = assembly.GetTypes().Where(t => t != type && typeof(PlayFactoryModule).IsAssignableFrom(t))
                    .Select(t => (IPlayFactoryModule) Activator.CreateInstance(t));

                var modulesAutoLoad = modules.Where(m => m.AutoLoad());

                Add(modulesAutoLoad);
            });
        }

        /// <summary>
        /// Método que inicializa o gerenciado de módulos.  
        /// </summary>
        /// <remarks>Este método desencadeará a inicialização de todos os módulos adicionados a aplicação.</remarks>
        /// <param name="container">ContainerIoC que será utilizado pelos módulos.</param>
        public void Initialize(ContainerBuilder container)
        {
            foreach (var module in Modules)
            {
                container.RegisterModule(module);
            }
        }
    }
}
