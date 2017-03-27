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
        /// Retorna um IQueryable para consulta da entidade representada pelo repositório.
        /// </summary>
        /// <returns>Retorna um IQueryable para consulta da entidade no banco de dados.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Adiciona o predicado a árvore de consulta e retorna um IQueryable.
        /// </summary>
        /// <returns>Retorna um IQueryable para consulta da entidade no banco de dados.</returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Usado para retornar um IQueryable para consulta da entidade representada 
        /// pelo repositório e fazer o include de propriedades com os dados do banco.. 
        /// </summary>
        /// <param name="propertySelectors">Uma lista de propriedades para include.</param>
        /// <returns>etorna um IQueryable para consulta da entidade no banco de dados</returns>
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        /// <summary>
        /// Usado para retornar todas as entidades.
        /// </summary>
        /// <returns>Retorna uma lista de entidades</returns>
        /// <remarks>Deverá ser utilizado com cuidado, pois o mesmo retornará para memória todos os dados da entidade.</remarks>
        List<TEntity> GetAllList();

        /// <summary>
        /// Usado para retornar todas as entidades de forma assíncrona.
        /// </summary>
        /// <returns>Retorna uma lista de entidades</returns>
        /// <remarks>Deverá ser utilizado com cuidado, pois o mesmo retornará para memória todos os dados da entidade.</remarks>
        Task<List<TEntity>> GetAllListAsync();

        /// <summary>
        /// Método usado para retornar uma lista de entidades com base em um predicado <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">predicado usado para filtrar</param>
        /// <returns>List of all entities</returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Método usado para retornar uma lista de entidades com base em um predicado <paramref name="predicate"/> de forma assíncrona.
        /// </summary>
        /// <param name="predicate">predicado usado para filtrar</param>
        /// <returns>List of all entities</returns>
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);



        /// <summary>
        /// Retorna apenas uma enyidade com base no predicado passado como parâmetro.
        /// Se não for encontrada nenhuma entidade ou for encontrada mais de uma, será lançado uma exceção.
        /// </summary>
        /// <param name="predicate">Predicado usado para consulta da entidade.</param>
        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Retorna apenas uma entidade com base no predicado passado como parâmetro de forma assíncrona.
        /// Se não for encontrada nenhuma entidade ou for encontrada mais de uma, será lançado uma exceção.
        /// </summary>
        /// <param name="predicate">Predicado usado para filtrar a entidade.</param>
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Retorna uma entidade com base no predicado passado como parâmetro, mas se não for encontrado nenhum valor será retornado null.
        /// </summary>
        /// <param name="predicate">Predicado usado para filtrar as entidades.</param>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Retorna a primeira entidade encontrada no repositório, mas se não for encontrado nenhum valor será retornado null.
        /// </summary>
        TEntity FirstOrDefault();

        /// <summary>
        /// Retorna uma entidade com base no predicado passado como parâmetro, mas se não for encontrado nenhum valor será retornado null.
        /// Este método será executado de forma assíncrona.
        /// </summary>
        /// <param name="predicate">Predicado usado para filtrar as entidades.</param>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Retorna a primeira entidade encontrada no repositório, mas se não for encontrado nenhum valor será retornado null.
        /// </summary>
        Task<TEntity> FirstOrDefaultAsync();

        #endregion

        #region Create

        /// <summary>
        /// Cria uma nova entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade à ser criada.</param>
        TEntity Create(TEntity entity);

        /// <summary>
        /// Cria uma nova entidade no banco de dados de forma assíncrona.
        /// </summary>
        /// <param name="entity">Entidade à ser criada.</param>
        Task<TEntity> CreateAsync(TEntity entity);


        #endregion

        #region Update

        /// <summary>
        /// Atualiza a entidade existente.
        /// </summary>
        /// <param name="entity">Entidade à ser atualizada</param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Atualiza a entidade existente de forma assíncrona.
        /// </summary>
        /// <param name="entity">Entidade à ser atualizada</param>
        Task<TEntity> UpdateAsync(TEntity entity);

        #endregion

        #region Delete

        /// <summary>
        /// Deleta a entidade.
        /// </summary>
        /// <param name="entity">Entidade a ser deletada</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deleta a entidade de forma assíncrona.
        /// </summary>
        /// <param name="entity">Entidade a ser deletada</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Deleta todas as entidades retornada pelo filtro do predicado.
        /// </summary>
        /// <remarks>Todas as entidades que obdecerem ao predicado serão recuperadas e excluídas. 
        /// Isso poderá causar uma lentida dependendo da quantidade de registros que obedecerem ao predicado.</remarks>
        /// <param name="predicate">Predicado usado para filtrar as entidades que serão deletadas</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Deleta todas as entidades retornada pelo filtro do predicado de forma assíncrona.
        /// </summary>
        /// <remarks>Todas as entidades que obdecerem ao predicado serão recuperadas e excluídas. 
        /// Isso poderá causar uma lentida dependendo da quantidade de registros que obedecerem ao predicado.</remarks>
        /// <param name="predicate">Predicado usado para filtrar as entidades que serão deletadas</param>
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
        /// Este método retorna a qunatidade das entidades que obedeceram ao critério do predicado <paramref name="predicate"/> de forma assíncrona.
        /// </summary>
        /// <param name="predicate">predicado usado para filtrar as entidades.</param>
        /// <returns>Quantidade de entidades que obedeceram ao critério do predicado.</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Retorna se existe entidade no repositório com base em um predicado.
        /// </summary>
        /// <param name="predicate">Predicado usado para filtrar o repositório.</param>
        /// <returns>Retorna se tem ou não entidade no repositório.</returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Retorna se existe entidade no repositório com base em um predicado de forma assincrona.
        /// </summary>
        /// <param name="predicate">Predicado usado para filtrar o repositório.</param>
        /// <returns>Retorna se tem ou não entidade no repositório.</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
