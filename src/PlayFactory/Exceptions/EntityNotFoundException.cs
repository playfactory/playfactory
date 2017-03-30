using System;

namespace PlayFactory.Exceptions
{
    /// <summary>
    /// Class used for entity Exception
    /// </summary>
    public class EntityNotFoundException : PlayFactoryException
    {
        /// <summary>
        /// Entity Type.
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        /// Entity ID.
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// Creates a new <see cref = "EntityNotFoundException" /> object.
        /// </summary>
        public EntityNotFoundException()
        {

        }

        /// <summary>
        /// Creates a new <see cref = "EntityNotFoundException" /> object.
        /// </summary>
        public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, null)
        {

        }

        /// <summary>
        /// Creates a new <see cref = "EntityNotFoundException" /> object.
        /// </summary>
        public EntityNotFoundException(Type entityType, object id, Exception innerException)
            : base($"Não foi encontrado o registro. Entidade: {entityType.FullName}, id: {id}", innerException)
        {
            EntityType = entityType;
            Id = id;
        }

        /// <summary>
        /// Creates a new <see cref = "EntityNotFoundException" /> object.
        /// <param name="message">Exception message</param>
        public EntityNotFoundException(string message)
            : base(message)
        {

        }

        /// <summary>
        ///Creates a new <see cref = "EntityNotFoundException" /> object.
        /// </summary>
        /// <param name="message">Message from Exception</param>
        /// <param name="innerException">Inner exception</param>
        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
