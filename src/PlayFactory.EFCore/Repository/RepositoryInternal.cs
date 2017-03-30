using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayFactory.Collection;
using PlayFactory.EFCore.Context;
using PlayFactory.EFCore.UnitOfWork;
using PlayFactory.Repository;

namespace PlayFactory.EFCore.Repository
{
    /// <inheritdoc />
    public class RepositoryInternal<TEntity> : IRepositoryInternal<TEntity>
        where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public virtual PlayFactoryDbContextBase Context => _unitOfWork.GetDbContext();
        public virtual DbSet<TEntity> DbSet => Context.Set<TEntity>();

        protected RepositoryInternal(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public virtual bool Any()
        {
            return GetAll().Any();
        }

        /// <inheritdoc />
        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Any(predicate);
        }

        /// <inheritdoc />
        public virtual Task<bool> AnyAsync()
        {
            return GetAll().AnyAsync();
        }

        /// <inheritdoc />
        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().AnyAsync(predicate);
        }

        /// <inheritdoc />
        public virtual int Count()
        {
            return GetAll().Count();
        }

        /// <inheritdoc />
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Count(predicate);
        }

        /// <inheritdoc />
        public virtual Task<int> CountAsync()
        {
            return GetAll().CountAsync();
        }

        /// <inheritdoc />
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().CountAsync(predicate);
        }

        /// <inheritdoc />
        public TEntity Create(TEntity entity)
        {
            var obj = DbSet.Add(entity).Entity;
            return obj;
        }

        /// <inheritdoc />
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var obj = (await DbSet.AddAsync(entity)).Entity;
            return obj;
        }

        /// <inheritdoc />
        public void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            DbSet.Remove(entity);
        }

        /// <inheritdoc />
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = GetAllList(predicate);

            foreach(var entity in entities)
            {
                Delete(entity);
            }
        }

        /// <inheritdoc />
        public Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await GetAllListAsync(predicate);

            foreach (var entity in entities)
            {
                await DeleteAsync(entity);
            }
        }

        /// <inheritdoc />
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc />
        public TEntity FirstOrDefault()
        {
            return GetAll().FirstOrDefault();
        }

        /// <inheritdoc />
        public async Task<TEntity> FirstOrDefaultAsync()
        {
            return await GetAll().FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc />
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        /// <inheritdoc />
        public virtual List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        /// <inheritdoc />
        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        /// <inheritdoc />
        public virtual async Task<List<TEntity>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();
        }

        /// <inheritdoc />
        public virtual async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }

        /// <inheritdoc />
        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Single();
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).SingleAsync();
        }

        /// <inheritdoc />
        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        /// <inheritdoc />
        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        /// <inheritdoc />
        public DbContext GetDbContext()
        {
            return Context;
        }

        /// <inheritdoc />
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            if (propertySelectors.IsNullOrEmpty())
            {
                return GetAll();
            }

            var query = GetAll();

            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }

            return query;
        }

        /// <inheritdoc />
        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = Context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            DbSet.Attach(entity);
        }

        /// <inheritdoc />
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
    }
}
