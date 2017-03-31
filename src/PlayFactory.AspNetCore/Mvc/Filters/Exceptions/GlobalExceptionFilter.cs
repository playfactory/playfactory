using Microsoft.AspNetCore.Mvc.Filters;
using PlayFactory.Events.Bus;
using PlayFactory.Events.Bus.Exceptions;

namespace PlayFactory.AspNetCore.Mvc.Filters.Exceptions
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

            _eventBus.Trigger(exceptionData);
        }
    }
}
