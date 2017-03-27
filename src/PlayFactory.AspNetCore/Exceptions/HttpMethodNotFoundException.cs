using System;
using System.Collections.Generic;
using System.Text;
using PlayFactory.Exceptions;

namespace PlayFactory.AspNetCore.Exceptions
{
    /// <summary>
    /// Exceção é será disparada um Verbo Http Não for encontrado.
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
