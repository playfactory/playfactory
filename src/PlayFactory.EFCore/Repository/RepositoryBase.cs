using PlayFactory.EFCore.UnitOfWork;
using PlayFactory.Repository;
using PlayFactory.UnitOfWork;

namespace PlayFactory.EFCore.Repository
{
    /// <inheritdoc />
    public class RepositoryBase<TEntity> : RepositoryInternal<TEntity>, IRepositoryBase<TEntity>
        where TEntity : class 
    {
        public RepositoryBase(IUnitOfWorkDbContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
