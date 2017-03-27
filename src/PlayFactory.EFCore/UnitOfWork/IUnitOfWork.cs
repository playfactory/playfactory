using System;
using PlayFactory.EFCore.Context;
using PlayFactory.IoC;

namespace PlayFactory.EFCore.UnitOfWork
{
    /// <summary>
    /// Interface de implementação do padrão Unit Of Work responsável pelo controle de transação da aplicação.
    /// </summary>
    public interface IUnitOfWork : IInstancePerLifetimeScopeDependency, IDisposable
    {
        /// <summary>
        /// Inicia o Controle de Transação.
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// Efetua o Commit da transação aberta pelo UnitOfWork.
        /// </summary>
        void Commit();
        /// <summary>
        /// Efetua o Roolback da transação aberta pelo UnitOfWork.
        /// </summary>
        void Roolback();
        /// <summary>
        /// Retorna o DbContext que pertence ao UnitOfWork.
        /// </summary>
        /// <returns></returns>
        PlayFactoryDbContextBase GetDbContext();
        /// <summary>
        /// Salva todas as alterações do Contexto do Banco de dados.
        /// </summary>
        void SaveChanges();
        /// <summary>
        /// Salva todas as alterações do Contexto do Banco de dados de forma assíncrona.
        /// </summary>
        void SaveChangesAsync();
    }
}
