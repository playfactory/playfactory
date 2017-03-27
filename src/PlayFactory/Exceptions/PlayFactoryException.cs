using System;

namespace PlayFactory.Exceptions
{
    /// <summary>
    /// Classe base para todas as exception do PlayFactory
    /// </summary>
    public class PlayFactoryException: Exception
    {
        /// <summary>
        /// Cria um novo <see cref="PlayFactoryException"/> objeto.
        /// </summary>
        public PlayFactoryException()
        {

        }

        /// <summary>
        /// Cria um novo <see cref="PlayFactoryException"/> objeto.
        /// </summary>
        /// <param name="message">Exception message</param>
        public PlayFactoryException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Cria um novo <see cref="PlayFactoryException"/> objeto.
        /// </summary>
        /// <param name="message">Mensagem da Exception</param>
        /// <param name="innerException">Inner exception</param>
        public PlayFactoryException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
