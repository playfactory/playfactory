using System;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using PlayFactory.EntityFrameworkCore;
using PlayFactory.Events.Bus;
using PlayFactory.IoC;
using PlayFactory.Modules;

namespace PlayFactory.AspNetCore.Extensions
{
    /// <summary>
    /// Help responsável por adicionar os serviços do PlayFactory a aplicação
    /// </summary>
    public static class PlayFactoryServiceCollectionExtensions
    {
        /// <summary>
        /// Adiciona o PlayFactory a Aplicação ASP.NET Core e defini as configurações de inicialização do PlayFactory.
        /// </summary>
        /// <param name="service">Objeto Help</param>
        /// <returns>Retorna o Provider do Autofac para controle do IoC</returns>
        public static IServiceProvider AddPlayFactory(this IServiceCollection service)
        {
            //var builder = ContainerIoC.ScopeContainer(container =>
            //{
            //    var moduleManager = PlayFactoryModules.Manager;
            //    AddModules(moduleManager);
            //    moduleManager.LoadModules();
            //    moduleManager.Initialize(container);

            //    container.Populate(service);

            //    return container.Build();
            //});

            //var container = new ContainerBuilder();


            var builder = ContainerIoC.ScopeContainer(container =>
            {
                container.RegisterModule(new PlayFactoryBaseModule());
                container.RegisterModule(new PlayFactoryEntityModule());
                container.RegisterModule(new PlayFactoryAspNetCoreModule());
                container.RegisterModule(new EventBusModule());

                var moduleManager = PlayFactoryModules.Manager;
                moduleManager.LoadModules();
                moduleManager.Initialize(container);

                container.Populate(service);

                return container.Build();
            });



            return builder.Resolve<IServiceProvider>();
        }

    }
}
