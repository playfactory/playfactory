using PlayFactory.Entity;

namespace PlayFactory.Repository
{
    /// <summary>
    /// Base interface for the entities that the Id is int.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
    }
}
