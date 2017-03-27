using Microsoft.EntityFrameworkCore.Storage;
using PlayFactory.EFCore.Context;

namespace PlayFactory.EFCore.UnitOfWork
{
    /// <summary>
    /// Classe de implementação do padrão Unit Of Work responsável pelo controle de transação da aplicação.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;

        public PlayFactoryDbContextBase DbContext { get; }

       
        public UnitOfWork(PlayFactoryDbContextBase dbContext)
        {
            DbContext = dbContext;
        }

        /// <inheritdoc />
        public void BeginTransaction()
        {
            _transaction = DbContext.Database.BeginTransaction();
        }

        /// <inheritdoc />
        public void Commit()
        {
            _transaction?.Commit();
        }

        /// <inheritdoc />
        public void Roolback()
        {
            _transaction?.Rollback();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            DbContext?.Dispose();
            _transaction?.Dispose();
        }

        /// <inheritdoc />
        public PlayFactoryDbContextBase GetDbContext()
        {
            return DbContext;
        }

        /// <inheritdoc />
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        /// <inheritdoc />
        public async void SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
