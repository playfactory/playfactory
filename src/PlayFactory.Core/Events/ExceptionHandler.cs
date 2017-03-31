using PlayFactory.Events.Bus.Exceptions;
using PlayFactory.Events.Bus.Handlers;

namespace PlayFactory.Core.Events
{
    public class ExceptionHandler : IEventHandler<PlayFactoryHandledExceptionData>
    {
        public void HandleEvent(PlayFactoryHandledExceptionData eventData)
        {
           
        }
    }
}
