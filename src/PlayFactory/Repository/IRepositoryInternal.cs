using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlayFactory.Repository
{
    public interface IRepositoryInternal<TEntity> : IRepository
        where TEntity : class
    {
        #region Select/Get/Query

        /// <summary>
        ///Returns an IQueryable for query of the entity represented by the repository.
        /// </summary>
        /// <returns>Returns an IQueryable for query of the entity in the database.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Adds the predicate to the query tree and returns an IQueryable.
        /// </summary>
        /// <returns>Returns an IQueryable for query of the entity in the database.</returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Used to return an IQueryable to query the entity represented by the repository and make 
        /// the property include with the database's data.
        /// </summary>
        /// <param name="propertySelectors">A list of properties to include.</param>
        /// <returns>Returns an IQueryable for query of the entity in the database</returns>
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        /// <summary>
        /// Used to return all entities.
        /// </summary>
        /// <returns>Returns a list of entities.</returns>
        /// <remarks>It should be used with care because it returns to memory all the data of the entity.</remarks>
        List<TEntity> GetAllList();

        /// <summary>
        /// Used to return all entities asynchronously.
        /// </summary>
        /// <returns>Returns a list of entities.</returns>
        /// <remarks>It should be used with care because it returns to memory all the data of the entity.</remarks>
        Task<List<TEntity>> GetAllListAsync();

        /// <summary>
        /// Method used to return a list of entities based on a predicate <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">Predicate used to filter.</param>
        /// <returns>List of all entities</returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Method used to return a list of entities based on a predicate <paramref name="predicate"/> Asynchronously.
        /// </summary>
        /// <param name="predicate">Predicate used to filter</param>
        /// <returns>List of all entities</returns>
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);



        /// <summary>
        /// Returns only one entity based on the predicate passed as a parameter.
        /// If no entity is found or more than one is found, an exception is thrown.
        /// </summary>
        /// <param name="predicate">Predicate used to query the entity.</param>
        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns only one entity based on the predicate passed as a parameter asynchronously.
        /// If no entity is found or more than one is found, an exception is thrown.
        /// </summary>
        /// <param name="predicate">Predicate used to filter entity.</param>
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns an entity based on the predicate passed as a parameter, but if it is not found no value is returned null.
        /// </summary>
        /// <param name="predicate">Predicate used to filter entities.</param>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns the first entity found in the repository, but if it is not found any value will be returned null.
        /// </summary>
        TEntity FirstOrDefault();

        /// <summary>
        /// Returns an entity based on the predicate passed as a parameter, but if it is not found no value is returned null.
        /// This method will be executed asynchronously.
        /// </summary>
        /// <param name="predicate">Predicate used to filter entities.</param>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns the first entity found in the repository, but if it is not found any value will be returned null.
        /// </summary>
        Task<TEntity> FirstOrDefaultAsync();

        #endregion

        #region Create

        /// <summary>
        /// Create a new entity in the database.
        /// </summary>
        /// <param name="entity">Entidade à ser criada.</param>
        TEntity Create(TEntity entity);

        /// <summary>
        ///Create a new entity in the database asynchronously.
        /// </summary>
        /// <param name="entity">Entidade à ser criada.</param>
        Task<TEntity> CreateAsync(TEntity entity);


        #endregion

        #region Update

        /// <summary>
        /// Updates the existing entity.
        /// </summary>
        /// <param name="entity">Entidade à ser atualizada</param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Updates the existing entity asynchronously.
        /// </summary>
        /// <param name="entity">Entity to be updated.</param>
        Task<TEntity> UpdateAsync(TEntity entity);

        #endregion

        #region Delete

        /// <summary>
        /// Delete the entity.
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete the entity asynchronously.
        /// </summary>
        /// <param name="entity">Entity to be deleted.</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        ///Delete all entities returned by the predicate filter.
        /// </summary>
        /// <remarks>All entities that obey the predicate will be recovered and deleted.
        /// This may cause a slowness depending on the amount of records that follow the predicate.</remarks>
        /// <param name="predicate">Predicate used to filter the entities to be deleted</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Delete all entities returned by the predicate filter asynchronously.
        /// </summary>
        /// <remarks>All entities that obey the predicate will be recovered and deleted.
        /// This may cause a slowness depending on the amount of records that follow the predicate.</remarks>
        /// <param name="predicate">Predicate used to filter the entities to be deleted</param>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Aggregates   

        /// <summary>
        /// Este método retorna a qunatidade das entidades que obedeceram ao critério do predicado <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">predicado usado para filtrar as entidades</param>
        /// <returns>Quantidade de entidades que obedeceram ao critério do predicado.</returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// This method returns the number of entities that obey the predicate criterion <paramref name="predicate"/> de forma assíncrona.
        /// </summary>
        /// <param name="predicate">Predicate used to filter entities.</param>
        /// <returns>Predicate used to filter entities.</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns whether there is an entity in the repository based on a predicate.
        /// </summary>
        /// <param name="predicate">Predicate used to filter the repository.</param>
        /// <returns>Whether or not it has entity in the repository.</returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Whether or not it has entity in the repository.
        /// </summary>
        /// <param name="predicate">Predicate used to filter the repository.</param>
        /// <returns>Whether or not it has entity in the repository.</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
