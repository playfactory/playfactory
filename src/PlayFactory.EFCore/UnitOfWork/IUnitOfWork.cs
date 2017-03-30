using System;
using PlayFactory.EFCore.Context;
using PlayFactory.IoC;

namespace PlayFactory.EFCore.UnitOfWork
{
    /// <summary>
    /// Unit Of Work standard implementation interface responsible for the transaction control of the application.
    /// </summary>
    public interface IUnitOfWork : IInstancePerLifetimeScopeDependency, IDisposable
    {
        /// <summary>
        /// Begin transaction in database
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// Commit the transaction from the Unit Of Work.
        /// </summary>
        void Commit();
        /// <summary>
        /// Perform Rollback of the transaction opened by Unit Of Work.
        /// </summary>
        void Roolback();
        /// <summary>
        /// Retorna o DbContext que pertence ao UnitOfWork.
        /// </summary>
        /// <returns></returns>
        PlayFactoryDbContextBase GetDbContext();
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
