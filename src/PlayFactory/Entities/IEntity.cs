namespace PlayFactory.Entities
{
    /// <summary>
    /// Base interface for entities with Int.
    /// </summary>
    public interface IEntity : IEntity<int>
    {
       
    }

    /// <summary>
    /// Base interface for entities with generic Id.
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IEntity<TPrimaryKey> 
    {
        /// <summary>
        /// Entity ID.
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// Checks whether the entity has the Id with default value or has been assigned an Id.
        /// </summary>
        /// <returns></returns>
        bool IsTransient();
    }
}
