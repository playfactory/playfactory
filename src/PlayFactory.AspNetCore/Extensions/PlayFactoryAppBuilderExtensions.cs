using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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

            return app;
        }

        private static void InitializePlayFactory(IApplicationBuilder app)
        {
            app.ApplicationServices.GetRequiredService<PlayFactoryBootstrapper>().Initialize();
        }
    }
}
