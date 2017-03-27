using System.Threading.Tasks;

namespace PlayFactory.Repository
{
    /// <summary>
    /// Interface base para todos os repositórios.
    /// </summary>
    public interface IRepository 
    {

        #region Aggregates

        /// <summary>
        /// Este método retorna a quantidade da entidade que está no banco de dados.
        /// </summary>
        /// <returns>Retorna a quantidade das entidades.</returns>
        int Count();

        /// <summary>
        /// Este método retorna a quantidade da entidade que está no banco de dados.
        /// </summary>
        /// <returns>Retorna a quantidade das entidades.</returns>
        Task<int> CountAsync();

        /// <summary>
        /// Retorna se existe entidade no repositório.
        /// </summary>
        /// <returns>Retorna se tem ou não entidade no repositório.</returns>
        bool Any();

        /// <summary>
        /// Retorna se existe entidade no repositório de forma assíncrona.
        /// </summary>
        /// <returns>Retorna se tem ou não entidade no repositório.</returns>
        Task<bool> AnyAsync();

        #endregion
    }

}