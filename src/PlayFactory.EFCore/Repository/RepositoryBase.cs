using PlayFactory.EFCore.UnitOfWork;
using PlayFactory.Repository;

namespace PlayFactory.EFCore.Repository
{
    public class RepositoryBase<TEntity> : RepositoryInternal<TEntity>, IRepositoryBase<TEntity>
        where TEntity : class 
    {
        public RepositoryBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
