using System;

namespace PlayFactory.Events.Bus.Exceptions
{
    /// <summary>
    /// This type of events are used to notify for exceptions handled by PlayFactory infrastructure.
    /// </summary>
    public class PlayFactoryHandledExceptionData : ExceptionData
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="exception">Exception object</param>
        public PlayFactoryHandledExceptionData(Exception exception)
            : base(exception)
        {

        }
    }
}