namespace PlayFactory.UnitOfWork
{
    public interface IActiveUnitOfWork
    {
        /// <summary>
        ///Saves all changes to the Database Context.
        /// </summary>
        void SaveChanges();
        /// <summary>
        /// Saves all changes to the Database Context asynchronously.
        /// </summary>
        void SaveChangesAsync();
    }
}
