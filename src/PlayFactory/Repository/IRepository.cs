using System.Threading.Tasks;

namespace PlayFactory.Repository
{
    /// <summary>
    /// Base interface for all repositories.
    /// </summary>
    public interface IRepository 
    {

        #region Aggregates

        /// <summary>
        /// This method returns the quantity of the entity that is in the database.
        /// </summary>
        /// <returns>Returns the number of entities.</returns>
        int Count();

        /// <summary>
        /// This method returns the amount of the entity that is in the database asynchronously.
        /// </summary>
        /// <returns>Returns the number of entities.</returns>
        Task<int> CountAsync();

        /// <summary>
        /// Returns whether there is an entity in the repository.
        /// </summary>
        /// <returns>Returns whether or not there is an entity in the repository.</returns>
        bool Any();

        /// <summary>
        /// Returns whether an entity exists in the repository asynchronously.
        /// </summary>
        /// <returns>Returns whether or not there is an entity in the repository.</returns>
        Task<bool> AnyAsync();

        #endregion
    }

}