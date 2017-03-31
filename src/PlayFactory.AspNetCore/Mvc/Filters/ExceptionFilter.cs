using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PlayFactory.AspNetCore.Mvc.Filters
{
    public class ExceptionFilter : IExceptionFilter, IDisposable
    {
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
