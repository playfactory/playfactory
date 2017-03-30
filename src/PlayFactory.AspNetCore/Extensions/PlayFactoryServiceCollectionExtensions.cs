using System;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using PlayFactory.AspNetCore.Mvc.Extensions;
using PlayFactory.IoC;

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
        /// <param name="services">Objeto Help</param>
        /// <returns>Retorna o Provider do Autofac para controle do IoC</returns>
        public static IServiceProvider AddPlayFactory(this IServiceCollection services)
        {
            var iocResolve = AddAutofac((container, resolve) =>
            {
                container.Populate(services);
                ConfigureAspNetCore(services);
                AddPlayFactoryBootstrap(resolve);
            });

            return new AutofacServiceProvider(iocResolve.Builder);
        }

        private static IIocResolver AddAutofac(Action<ContainerBuilder, IocResolver> preBuild)
        {
            var iocResolve = IocResolver.Instance;

            iocResolve.ContainerBuilder.Register(c => iocResolve)
                .As<IIocResolver>()
                .SingleInstance();

            preBuild?.Invoke(iocResolve.ContainerBuilder, iocResolve);

            var builder = iocResolve.Build();

            return builder.Resolve<IIocResolver>();
        }

        private static void ConfigureAspNetCore(IServiceCollection services)
        {
            services.Configure<MvcOptions>(mvcOptions => mvcOptions.AddPlayFactory(services));
        }

        private static void AddPlayFactoryBootstrap(IIocResolver iocResolver)
        {
            var bootstrap = PlayFactoryBootstrapper.Create(iocResolver);
            iocResolver.ContainerBuilder
                .Register(c => bootstrap)
                .PropertiesAutowired()
                .AsSelf()
                .SingleInstance();
        }
    }
}
