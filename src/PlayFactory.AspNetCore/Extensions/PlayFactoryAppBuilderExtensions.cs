using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlayFactory.AspNetCore.Extensions
{
    public static class PlayFactoryAppBuilderExtensions
    {
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
