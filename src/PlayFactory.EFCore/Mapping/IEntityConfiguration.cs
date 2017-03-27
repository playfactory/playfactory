using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace PlayFactory.EntityFrameworkCore.Mapping
{
    /// <summary>
    /// Interface de Configuração de mapeamento do EntityFramework
    /// </summary>
    public interface IEntityConfiguration
    {
        /// <summary>
        /// Deverá ser implementado a configuração de Mapeamento do EntityFramework.
        /// </summary>
        void Configuration();
        /// <summary>
        /// Método para inicializar o mapeamento do EntityFramework.
        /// </summary>
        /// <param name="modelBuilder">MOdelBuilder do DbContext</param>
        /// <returns>Retorna a interface fluent de Configuração do Mapeamento.</returns>
        IEntityConfiguration Initialize(ModelBuilder modelBuilder);
    }

    /// <summary>
    /// Interface deConfiguração do Mapeamento do EntityFramework.
    /// </summary>
    /// <typeparam name="TEntity">Entidade que será configurada.</typeparam>
    public interface IEntityConfiguration<TEntity> : IEntityConfiguration where TEntity : class
    {
        /// <summary>
        /// Mepamento da propriedade da entidade.
        /// </summary>
        /// <typeparam name="TProperty">Tipo da propriedade mapeada.</typeparam>
        /// <param name="propertyExpression">Definição da propriedade</param>
        /// <returns>Retorna a configuração da propriedade</returns>
        PropertyBuilder<TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression);
        /// <summary>
        /// Define o nome da tabela que a entidade representa.
        /// </summary>
        /// <param name="name">Nome da tabela</param>
        /// <returns>Retorna a configuração da tabela</returns>
        EntityTypeBuilder<TEntity> ToTable(string name);
        /// <summary>
        /// Define a propriedade que será a chave primária da tabela.
        /// </summary>
        /// <param name="keyExpression">Propriedade que representa a chave primária.</param>
        /// <returns>Retorna a configuração da chave primária.</returns>
        KeyBuilder HasKey(Expression<Func<TEntity, object>> keyExpression); 
    }
}
