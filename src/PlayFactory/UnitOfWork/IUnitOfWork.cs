using System;
using PlayFactory.IoC;

namespace PlayFactory.UnitOfWork
{
    /// <summary>
    /// Unit Of Work standard implementation interface responsible for the transaction control of the application.
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IInstancePerLifetimeScopeDependency, IDisposable
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
    }
}
