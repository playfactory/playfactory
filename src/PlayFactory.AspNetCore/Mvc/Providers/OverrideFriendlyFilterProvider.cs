using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayFactory.AspNetCore.Mvc.Filters;

namespace PlayFactory.AspNetCore.Mvc.Providers
{
    public class OverrideFriendlyFilterProvider : INestedProvider<FilterProviderContext>
    {
        //all framework providers have negative orders, so ours will come later
        public int Order => 0;

        public override void Invoke(FilterProviderContext context, Action callNext)
        {
            //let the whole provider pipeline run first
            if (callNext != null)
            {
                callNext();
            }

            if (context.ActionContext.ActionDescriptor.FilterDescriptors != null)
            {
                var overrideFilters = context.Results.Where(filterItem => filterItem.Filter is OverrideFilter).ToArray();
                foreach (var overrideFilter in overrideFilters)
                {
                    context.Results.RemoveAll(filterItem =>
                    filterItem.Descriptor.Filter.GetType() == ((OverrideFilter)overrideFilter.Filter).Type &&
                    filterItem.Descriptor.Scope <= overrideFilter.Descriptor.Scope);
                }
            }
        }
    }
}
