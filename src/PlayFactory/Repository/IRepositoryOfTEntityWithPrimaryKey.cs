using System;
using System.Threading.Tasks;
using PlayFactory.Entity;

namespace PlayFactory.Repository
{
    /// <summary>
    /// Interface Genérica para para os repositórios
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : IRepositoryInternal<TEntity> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        #region Select/Get/Query

        /// <summary>
        /// Retorna uma entidade com base no chave primária.
        /// </summary>
        /// <param name="id">Id da entidade.</param>
        /// <returns>Retorna uma entidade com base no seu Id.</returns>
        TEntity Get(TPrimaryKey id);

        /// <summary>
        /// Retorna uma entidade com base no chave primária de forma assíncrona.
        /// </summary>
        /// <param name="id">Id da entidade.</param>
        /// <returns>Retorna uma entidade com base no seu Id.</returns>
        Task<TEntity> GetAsync(TPrimaryKey id);

        /// <summary>
        /// Retorna uma entidade com base no Id, mas se não for encontrado nenhma entidade, será retornado null.
        /// </summary>
        /// <param name="id">Id da entidade</param>
        /// <returns>Entidade ou null</returns>
        TEntity FirstOrDefault(TPrimaryKey id);

        /// <summary>
        /// Retorna uma entidade com base no Id, mas se não for encontrado nenhma entidade, será retornado null.
        /// Este método será executado de forma assíncrona.
        /// </summary>
        /// <param name="id">Id da entidade</param>
        /// <returns>Entidade ou null</returns>
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        #endregion

        #region Create

        /// <summary>
        /// Cria uma nova entidade e retorna o seu Id.
        /// </summary>
        /// <remarks>Poderá ser necessário efetuar o commit do UnitOfWork para retornar o Id</remarks>
        /// <param name="entity">Entidade a ser criada no Banco de dados</param>
        /// <returns>Id da entidade criada</returns>
        TPrimaryKey CreateAndGetId(TEntity entity);

        /// <summary>
        /// Cria uma nova entidade e retorna o seu Id de forma assíncrona.
        /// </summary>
        /// <remarks>Poderá ser necessário efetuar o commit do UnitOfWork para retornar o Id</remarks>
        /// <param name="entity">Entidade a ser criada no Banco de dados</param>
        /// <returns>Id da entidade criada</returns>
        Task<TPrimaryKey> CreateAndGetIdAsync(TEntity entity);

        #endregion

        #region Update

        /// <summary>
        /// Cria ou Atualiza a entidade dependendo do Id.
        /// </summary>
        /// <remarks>Será criada a entidade se o Id for igual a 0, caso contrário, será efetuado o update</remarks>
        /// <param name="entity">Entidade a ser criada ou atualizada.</param>
        TEntity CreateOrUpdate(TEntity entity);

        /// <summary>
        /// Cria ou Atualiza a entidade de forma assíncrona dependendo do Id.
        /// </summary>
        /// <remarks>Será criada a entidade se o Id for igual a 0, caso contrário, será efetuado o update</remarks>
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
        /// Cria ou Atualiza a entidade de forma assíncrona dependendo do Id.
        /// </summary>
        /// <remarks>
        /// Será criada a entidade se o Id for igual a 0, caso contrário, será efetuado o update. 
        /// Poderá ser necessário efetuar o commit do UnitOfWork para retornar o Id
        /// </remarks>
        /// <param name="entity">Entidade a ser criada ou atualizada.</param>
        /// <returns>Retorna o Id da Entidade</returns>
        Task<TPrimaryKey> CreateOrUpdateAndGetIdAsync(TEntity entity);

        /// <summary>
        /// Atualiza a entidade existente.
        /// </summary>
        /// <param name="id">Id da entidade a ser atualizada</param>
        /// <param name="updateAction">Action que será utilizada para alterar o valor da entidade.</param>
        /// <returns>Retorna a entidade atualizada.</returns>
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        /// <summary>
        /// Atualiza a entidade existente de forma assíncrona.
        /// </summary>
        /// <param name="id">Id da entidade a ser atualizada</param>
        /// <param name="updateAction">Action que será utilizada para alterar o valor da entidade.</param>
        /// <returns>Retorna a entidade atualizada.</returns>
        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);

        #endregion

        #region Delete

        /// <summary>
        /// Deleta a entidade com base no Id.
        /// </summary>
        /// <param name="id">Id da entidade que será deletada.</param>
        void Delete(TPrimaryKey id);

        /// <summary>
        /// Deleta a entidade com base no Id de forma assíncrona.
        /// </summary>
        /// <param name="id">Id da entidade que será deletada.</param>
        Task DeleteAsync(TPrimaryKey id);

        #endregion
    }
}
