using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PlayFactory.AspNetCore.Filters;

namespace PlayFactory.AspNetCore.Mvc.Extensions
{
    public static class PlayFactoryMvcOptionsExtensions
    {
        public static void AddPlayFactory(this MvcOptions options, IServiceCollection services)
        {
            AddFilters(options);
        }

        private static void AddFilters(MvcOptions options)
        {
            options.Filters.AddService(typeof(UnitOfWorkAttribute));
        }

    }
}
