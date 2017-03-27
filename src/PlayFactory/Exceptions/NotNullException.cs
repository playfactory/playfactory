using System;

namespace PlayFactory.Exceptions
{
    public class NotNullException : PlayFactoryException
    {
        public NotNullException()
        {
        }

        public NotNullException(string message) : base(message)
        {
        }

        public NotNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
