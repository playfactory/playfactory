using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PlayFactory.AspNetCore.Mvc.Filters
{
    public class OverrideFilter : ActionFilterAttribute
    {
        public Type Type { get; set; }

        public OverrideFilter()
        { }

        public OverrideFilter(Type type)
        {
            Type = type;
        }
    }
}
