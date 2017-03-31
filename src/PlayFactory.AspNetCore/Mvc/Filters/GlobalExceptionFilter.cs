using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using PlayFactory.Events.Bus;
using PlayFactory.Events.Bus.Exceptions;

namespace PlayFactory.AspNetCore.Mvc.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IEventBus _eventBus;

        public GlobalExceptionFilter(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void OnException(ExceptionContext context)
        {
            var exceptionData = new PlayFactoryHandledExceptionData(context.Exception);

            _eventBus.TriggerAsync(exceptionData);
        }
    }
}
