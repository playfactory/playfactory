using PlayFactory.Events.Bus.Exceptions;
using PlayFactory.Events.Bus.Handlers;

namespace Exemplos.WebApi
{
    public class ExceptionWebApi : IEventHandler<PlayFactoryHandledExceptionData>
    {
        public void HandleEvent(PlayFactoryHandledExceptionData eventData)
        {

        }
    }
}
