using System;
using PlayFactory.Exceptions;

namespace PlayFactory.AspNetCore.Exceptions
{
    /// <summary>
    /// Exception is will be fired an Http Verb Not Found.
    /// </summary>
    public class HttpMethodNotFoundException : PlayFactoryException
    {
        public HttpMethodNotFoundException()
        {
        }

        public HttpMethodNotFoundException(string message) : base(message)
        {
        }

        public HttpMethodNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
