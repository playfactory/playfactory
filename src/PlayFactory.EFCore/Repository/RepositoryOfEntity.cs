using PlayFactory.EFCore.UnitOfWork;
using PlayFactory.Entities;
using PlayFactory.Repository;
using PlayFactory.UnitOfWork;

namespace PlayFactory.EFCore.Repository
{
    /// <inheritdoc />
    public class RepositoryOfEntity<TEntity>: RepositoryOfEntityWithPrimaryKey<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public RepositoryOfEntity(IUnitOfWorkDbContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
