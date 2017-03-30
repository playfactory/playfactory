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
    /// Help responsible for adding the PlayFactory services to the application
    /// </summary>
    public static class PlayFactoryServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the PlayFactory to the ASP.NET Core Application and sets the PlayFactory startup settings.
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns>Returns the Autofac Provider for IoC control</returns>
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
