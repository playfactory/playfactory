using System;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlayFactory;
using PlayFactory.AspNetCore.Extensions;
using PlayFactory.AspNetCore.Mvc.Extensions;
using PlayFactory.AspNetCore.Mvc.Filters;
using PlayFactory.EFCore.Context;
using PlayFactory.IoC;

namespace Exemplos.WebApi
{
    public class Startup
    {
        public interface ITeste
        {
            
        }
        public class Teste : ITeste
        {
            
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Teste>(new Teste());

            services.AddDbContext<PlayFactoryDbContextBase>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.Configure<MvcOptions>(mvcOptions =>
            //{
            //    mvcOptions.AddPlayFactory(services);
            //});

            // Add framework services.
            services.AddMvc(o =>
            {
                //o.Filters.Add(new UnitOfWorkAttribute());
            });

            return services.AddPlayFactory();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UsePlayFactory();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
