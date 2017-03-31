using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PlayFactory.AspNetCore.Mvc.Filters;

namespace PlayFactory.AspNetCore.Mvc.Extensions
{
    /// <summary>
    /// Help for MvcOptions
    /// </summary>
    public static class PlayFactoryMvcOptionsExtensions
    {
        /// <summary>
        /// Returns the Autofac Provider for IoC control...
        /// </summary>
        /// <param name="options">Mvc Options</param>
        /// <param name="services">Service Collection</param>
        public static void AddPlayFactory(this MvcOptions options, IServiceCollection services)
        {
            AddFilters(options);
        }

        private static void AddFilters(MvcOptions options)
        {
            options.Filters.Add(typeof(UnitOfWorkFilter));
        }

    }
}
