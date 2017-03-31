using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayFactory.AspNetCore.Exceptions;
using PlayFactory.AspNetCore.Mvc.Filters;

namespace PlayFactory.AspNetCore.Mvc.Providers
{
    public class OverrideFilterProvider : IFilterProvider
    {
        public int Order { get; }

        public OverrideFilterProvider()
        {
            Order = 0;
        }

        public void OnProvidersExecuting(FilterProviderContext context)
        {
            if (context.ActionContext.ActionDescriptor.FilterDescriptors == null)
                return;

            var overrideFilters = context.Results.Where(filterItem => filterItem.Filter is OverrideFilter).ToArray();
            foreach (var overrideFilter in overrideFilters)
            {
                var filter = (overrideFilter.Filter as OverrideFilter);

                if (filter == null)
                    continue;

                if (filter.GetType() == filter.Type)
                    throw new ProviderException($"It is not allowed to override the type itself. Filter Type: {filter.GetType()} -> Overwritten Filter: {filter.Type}");

                var filters = context.Results.Where(filterItem =>
                    filterItem.Filter.GetType() == filter.Type &&
                    filterItem.Descriptor.Scope <= overrideFilter.Descriptor.Scope).ToList();

                foreach (var filterItem in filters)
                {
                    context.Results.Remove(filterItem);
                }
            }
        }

        public void OnProvidersExecuted(FilterProviderContext context)
        {
            //throw new NotImplementedException();
        }

       
    }
}
