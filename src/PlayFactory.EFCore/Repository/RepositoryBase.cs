using PlayFactory.EntityFrameworkCore.UnitOfWork;
using PlayFactory.Repository;

namespace PlayFactory.EntityFrameworkCore.Repository
{
    public class RepositoryBase<TEntity> : RepositoryInternal<TEntity>, IRepositoryBase<TEntity>
        where TEntity : class 
    {
        public RepositoryBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
