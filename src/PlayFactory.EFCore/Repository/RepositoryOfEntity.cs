using PlayFactory.EFCore.UnitOfWork;
using PlayFactory.Entity;
using PlayFactory.Repository;

namespace PlayFactory.EFCore.Repository
{
    public class RepositoryOfEntity<TEntity>: RepositoryOfEntityWithPrimaryKey<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public RepositoryOfEntity(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
