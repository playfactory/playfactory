using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlayFactory.IoC;

namespace PlayFactory.AspNetCore.Extensions
{
    /// <summary>
    /// Class Help IApplicationBuilder. 
    /// </summary>
    public static class PlayFactoryAppBuilderExtensions
    {
        /// <summary>
        ///Defines that the application will use the framework PlayFactory.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UsePlayFactory(this IApplicationBuilder app)
        {
            InitializePlayFactory(app);
            ReleaseAutofac(app);

            return app;
        }

        private static void InitializePlayFactory(IApplicationBuilder app)
        {
            var playfactoryBootstrapper = app.ApplicationServices.GetRequiredService<PlayFactoryBootstrapper>();
            playfactoryBootstrapper.Initialize();
        }

        private static void ReleaseAutofac(IApplicationBuilder app)
        {
            var appLifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

            appLifetime.ApplicationStopped.Register(() =>
            {
                IocResolver.Instance.Builder.Dispose();
            });
        }
    }
}
