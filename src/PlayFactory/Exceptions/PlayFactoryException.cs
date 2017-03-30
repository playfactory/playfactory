using System;

namespace PlayFactory.Exceptions
{
    /// <summary>
    /// Base class for all PlayFactory exception
    /// </summary>
    public class PlayFactoryException: Exception
    {
        /// <summary>
        /// Creates a new <see cref = "PlayFactoryException" /> object.
        /// </summary>
        public PlayFactoryException()
        {

        }

        /// <summary>
        /// Creates a new <see cref = "PlayFactoryException" /> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public PlayFactoryException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref = "PlayFactoryException" /> object.
        /// </summary>
        /// <param name="message">Message from exception</param>
        /// <param name="innerException">Inner exception</param>
        public PlayFactoryException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
