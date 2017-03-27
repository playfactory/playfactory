namespace PlayFactory.Repository
{
    public interface IRepositoryBase<TEntity> : IRepositoryInternal<TEntity>
        where TEntity : class 
    {
    }
}
