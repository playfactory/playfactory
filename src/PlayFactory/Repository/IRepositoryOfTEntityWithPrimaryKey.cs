using System;
using System.Threading.Tasks;
using PlayFactory.Entities;

namespace PlayFactory.Repository
{
    /// <summary>
    /// Generic interface for repositories
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : IRepositoryInternal<TEntity> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        #region Select/Get/Query

        /// <summary>
        ///Returns an entity based on the primary key.
        /// </summary>
        /// <param name="id">Entity ID.</param>
        /// <returns>Returns an entity based on its Id.</returns>
        TEntity Get(TPrimaryKey id);

        /// <summary>
        /// Returns an entity based on the primary key asynchronously.
        /// </summary>
        /// <param name="id">Entity ID.</param>
        /// <returns>Returns an entity based on its Id.</returns>
        Task<TEntity> GetAsync(TPrimaryKey id);

        /// <summary>
        ///Returns an entity based on the Id, but if no entity is found, null is returned.
        /// </summary>
        /// <param name="id">Entity ID.</param>
        /// <returns>Entity or null</returns>
        TEntity FirstOrDefault(TPrimaryKey id);

        /// <summary>
        /// Returns an entity based on the Id, but if no entity is found, null is returned.
        /// This method will be executed asynchronously.
        /// </summary>
        /// <param name="id">Entity ID.</param>
        /// <returns>Entity or null</returns>
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        #endregion

        #region Create

        /// <summary>
        /// Create a new entity and return your ID.
        /// </summary>
        /// <remarks>You may need to commit UnitOfWork to return the Id</remarks>
        /// <param name="entity">Entity to be created in the Database.</param>
        /// <returns>Created entity ID</returns>
        TPrimaryKey CreateAndGetId(TEntity entity);

        /// <summary>
        /// Cria uma nova entidade e retorna o seu Id de forma assíncrona.
        /// </summary>
        /// <remarks>You may need to commit UnitOfWork to return the Id</remarks>
        /// <param name="entity">Entity to be created in the Database.</param>
        /// <returns>Created entity ID</returns>
        Task<TPrimaryKey> CreateAndGetIdAsync(TEntity entity);

        #endregion

        #region Update

        /// <summary>
        /// Create or update the entity depending on the ID.
        /// </summary>
        /// <remarks>The entity will be created if Id is equal to 0, otherwise the update will be performed</remarks>
        /// <param name="entity">Entidade a ser criada ou atualizada.</param>
        TEntity CreateOrUpdate(TEntity entity);

        /// <summary>
        /// Creates or updates the entity asynchronously depending on the ID.
        /// </summary>
        /// <remarks>The entity will be created if Id is equal to 0, otherwise the update will be performed</remarks>
        /// <param name="entity">Entidade a ser criada ou atualizada.</param>
        Task<TEntity> CreateOrUpdateAsync(TEntity entity);

        /// <summary>
        /// Cria ou Atualiza a entidade dependendo do Id.
        /// </summary>
        /// <remarks>
        /// Será criada a entidade se o Id for igual a 0, caso contrário, será efetuado o update. 
        /// Poderá ser necessário efetuar o commit do UnitOfWork para retornar o Id
        /// </remarks>
        /// <param name="entity">Entidade a ser criada ou atualizada.</param>
        /// <returns>Retorna o Id da Entidade</returns>
        TPrimaryKey CreateOrUpdateAndGetId(TEntity entity);

        /// <summary>
        /// Creates or updates the entity asynchronously depending on the ID.
        /// </summary>
        /// <remarks>
        /// The entity will be created if Id is equal to 0, otherwise the update will be performed.
        /// You may need to commit UnitOfWork to return the Id
        /// </remarks>
        /// <param name="entity">Entidade a ser criada ou atualizada.</param>
        /// <returns>Retorna o Id da Entidade</returns>
        Task<TPrimaryKey> CreateOrUpdateAndGetIdAsync(TEntity entity);

        /// <summary>
        /// Updates the existing entity.
        /// </summary>
        /// <param name="id">Event ID to update</param>
        /// <param name="updateAction">Action that will be used to change the value of the entity.</param>
        /// <returns>Returns the updated entity.</returns>
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        /// <summary>
        /// Updates the existing entity asynchronously.
        /// </summary>
        /// <param name="id">Event ID to update.</param>
        /// <param name="updateAction">Action that will be used to change the value of the entity.</param>
        /// <returns>Returns the updated entity.</returns>
        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);

        #endregion

        #region Delete

        /// <summary>
        /// Delete the entity based on the Id.
        /// </summary>
        /// <param name="id">Id of the entity to be deleted.</param>
        void Delete(TPrimaryKey id);

        /// <summary>
        /// Delete the entity based on the Id asynchronously.
        /// </summary>
        /// <param name="id">Id of the entity to be deleted.</param>
        Task DeleteAsync(TPrimaryKey id);

        #endregion
    }
}
