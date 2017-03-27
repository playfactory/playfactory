using PlayFactory.Entity;
using PlayFactory.EntityFrameworkCore.UnitOfWork;
using PlayFactory.Repository;

namespace PlayFactory.EntityFrameworkCore.Repository
{
    public class RepositoryOfEntity<TEntity>: RepositoryOfEntityWithPrimaryKey<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public RepositoryOfEntity(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
