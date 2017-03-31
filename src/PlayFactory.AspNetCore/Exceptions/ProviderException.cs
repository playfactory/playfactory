using System;
using PlayFactory.Exceptions;

namespace PlayFactory.AspNetCore.Exceptions
{
    public class ProviderException : PlayFactoryException
    {
        public ProviderException()
        {
        }

        public ProviderException(string message) : base(message)
        {
        }

        public ProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
