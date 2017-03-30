namespace PlayFactory.Repository
{
    /// <inheritdoc />
    public interface IRepositoryBase<TEntity> : IRepositoryInternal<TEntity>
        where TEntity : class 
    {
    }
}
