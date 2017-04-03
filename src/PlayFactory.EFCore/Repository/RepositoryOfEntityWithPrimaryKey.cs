using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayFactory.EFCore.UnitOfWork;
using PlayFactory.Entities;
using PlayFactory.Exceptions;
using PlayFactory.Repository;
using PlayFactory.UnitOfWork;

namespace PlayFactory.EFCore.Repository
{
    public class RepositoryOfEntityWithPrimaryKey<TEntity, TPrimaryKey> : RepositoryInternal<TEntity>, IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public RepositoryOfEntityWithPrimaryKey(IUnitOfWorkDbContext unitOfWork) : base(unitOfWork)
        {
        }

        /// <inheritdoc />
        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await GetAll().FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        /// <inheritdoc />
        public TPrimaryKey CreateAndGetId(TEntity entity)
        {
            entity = Create(entity);

            if (entity.IsTransient())
            {
                Context.SaveChanges();
            }

            return entity.Id;
        }

        /// <inheritdoc />
        public async Task<TPrimaryKey> CreateAndGetIdAsync(TEntity entity)
        {
            entity = await CreateAsync(entity);

            if (entity.IsTransient())
            {
                await Context.SaveChangesAsync();
            }

            return entity.Id;
        }

        /// <inheritdoc />
        public virtual TEntity CreateOrUpdate(TEntity entity)
        {
            return entity.IsTransient()
                ? Create(entity)
                : Update(entity);
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> CreateOrUpdateAsync(TEntity entity)
        {
            return entity.IsTransient()
                ? await CreateAsync(entity)
                : await UpdateAsync(entity);
        }

        /// <inheritdoc />
        public TPrimaryKey CreateOrUpdateAndGetId(TEntity entity)
        {
            entity = CreateOrUpdate(entity);

            if (entity.IsTransient())
            {
                Context.SaveChanges();
            }

            return entity.Id;
        }

        /// <inheritdoc />
        public async Task<TPrimaryKey> CreateOrUpdateAndGetIdAsync(TEntity entity)
        {
            entity = await CreateOrUpdateAsync(entity);

            if (entity.IsTransient())
            {
                await Context.SaveChangesAsync();
            }

            return entity.Id;
        }

        /// <inheritdoc />
        public void Delete(TPrimaryKey id)
        {
            var entity = GetFromChangeTrackerOrNull(id);
            if (entity != null)
            {
                Delete(entity);
                return;
            }

            entity = FirstOrDefault(id);
            if (entity == null)
                return;

            Delete(entity);

            //Could not found the entity, do nothing.
        }

        /// <inheritdoc />
        public virtual TEntity Get(TPrimaryKey id)
        {
            var entity = FirstOrDefault(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            return entity;
        }

        /// <inheritdoc />
        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await FirstOrDefaultAsync(id);
        }

        /// <inheritdoc />
        private TEntity GetFromChangeTrackerOrNull(TPrimaryKey id)
        {
            var entry = Context.ChangeTracker.Entries()
                .FirstOrDefault(
                    ent =>
                        ent.Entity is TEntity &&
                        EqualityComparer<TPrimaryKey>.Default.Equals(id, ((TEntity) ent.Entity).Id)
                );

            return entry?.Entity as TEntity;
        }

        /// <inheritdoc />
        public Task DeleteAsync(TPrimaryKey id)
        {
            Delete(id);
            return Task.FromResult(0);
        }

        /// <inheritdoc />
        public virtual TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            var entity = Get(id);
            updateAction(entity);
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            var entity = Get(id);
            await updateAction(entity);
            return entity;
        }

        /// <summary>
        /// Create an expression by evaluating whether the entity ID is equal to the Id passed as a parameter.
        /// </summary>
        /// <param name="id">Id utilizado pelo filtro.</param>
        /// <returns>Expression with Filter By Id.</returns>
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}
