using PlayFactory.Entity;

namespace PlayFactory.Repository
{
    /// <summary>
    /// Interface base para as entidades que o Id é int.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
    }
}
