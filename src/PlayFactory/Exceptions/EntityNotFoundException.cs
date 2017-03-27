using System;

namespace PlayFactory.Exceptions
{
    /// <summary>
    /// Classe utilizado para Exceptionda entidade
    /// </summary>
    public class EntityNotFoundException : PlayFactoryException
    {
        /// <summary>
        /// Tipo da Entidade.
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        /// Id da entidade.
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// Cria um novo <see cref="EntityNotFoundException"/> objeto.
        /// </summary>
        public EntityNotFoundException()
        {

        }

        /// <summary>
        /// Cria um novo <see cref="EntityNotFoundException"/> objeto.
        /// </summary>
        public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, null)
        {

        }

        /// <summary>
        /// Cria um novo <see cref="EntityNotFoundException"/> objeto.
        /// </summary>
        public EntityNotFoundException(Type entityType, object id, Exception innerException)
            : base($"Não foi encontrado o registro. Entidade: {entityType.FullName}, id: {id}", innerException)
        {
            EntityType = entityType;
            Id = id;
        }

        /// <summary>
        /// Cria um novo <see cref="EntityNotFoundException"/> objeto.
        /// </summary>
        /// <param name="message">Exception message</param>
        public EntityNotFoundException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Cria um novo <see cref="EntityNotFoundException"/> objeto.
        /// </summary>
        /// <param name="message">Mensagem da Exception</param>
        /// <param name="innerException">Inner exception</param>
        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
