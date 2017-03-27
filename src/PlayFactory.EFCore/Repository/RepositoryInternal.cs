using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PlayFactory.Collection;
using PlayFactory.EntityFrameworkCore.Context;
using PlayFactory.EntityFrameworkCore.UnitOfWork;
using PlayFactory.Repository;

namespace PlayFactory.EntityFrameworkCore.Repository
{
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

        public virtual bool Any()
        {
            return GetAll().Any();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Any(predicate);
        }

        public virtual Task<bool> AnyAsync()
        {
            return GetAll().AnyAsync();
        }

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().AnyAsync(predicate);
        }

        public virtual int Count()
        {
            return GetAll().Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Count(predicate);
        }

        public virtual Task<int> CountAsync()
        {
            return GetAll().CountAsync();
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().CountAsync(predicate);
        }

        public TEntity Create(TEntity entity)
        {
            var obj = DbSet.Add(entity).Entity;
            return obj;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var obj = (await DbSet.AddAsync(entity)).Entity;
            return obj;
        }

        public void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = GetAllList(predicate);

            foreach(var entity in entities)
            {
                Delete(entity);
            }
        }

        public Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await GetAllListAsync(predicate);

            foreach (var entity in entities)
            {
                await DeleteAsync(entity);
            }
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public TEntity FirstOrDefault()
        {
            return GetAll().FirstOrDefault();
        }

        public async Task<TEntity> FirstOrDefaultAsync()
        {
            return await GetAll().FirstOrDefaultAsync();
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public virtual async Task<List<TEntity>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }       

        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Single();
        }

        public virtual async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).SingleAsync();
        }

        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        public DbContext GetDbContext()
        {
            return Context;
        }

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

        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = Context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            DbSet.Attach(entity);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
    }
}
