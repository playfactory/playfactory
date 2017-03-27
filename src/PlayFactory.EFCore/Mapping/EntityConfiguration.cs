using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace PlayFactory.EntityFrameworkCore.Mapping
{
    /// <summary>
    /// Classe base para as classes de mapeamento das entidades.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityConfiguration<TEntity> : IEntityConfiguration<TEntity> where TEntity : class
    {
        private EntityTypeBuilder<TEntity> _builder;

        /// <summary>
        /// Retorna o EntityTypeBuilder.
        /// </summary>
        /// <returns>EntityTypeBuilder</returns>
        protected EntityTypeBuilder<TEntity> GetBuilder()
        {
            if (_builder == null)
                throw new Exception("Initialize did not run");

            return _builder;
        }

        /// <summary>
        /// Classe que será executada quando for inicializado a configuração do EntityConfiguration
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public IEntityConfiguration Initialize(ModelBuilder modelBuilder)
        {
            _builder = modelBuilder.Entity<TEntity>();
            return this;
        }

        /// <summary>
        /// Configuração da Property.
        /// </summary>
        /// <typeparam name="TProperty">Type da Property.</typeparam>
        /// <param name="propertyExpression">Expression que define a property mapeada.</param>
        /// <returns>Retorna um PropertyBuilder para configuração da property.</returns>
        public PropertyBuilder<TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            return GetBuilder().Property(propertyExpression);
        }

        /// <summary>
        /// Define o nome da tabela.
        /// </summary>
        /// <param name="name">Nome da tabela</param>
        /// <returns>Retorna o EntityTypeBuilder com a configuração da tabela.</returns>
        public EntityTypeBuilder<TEntity> ToTable(string name)
        {
            return GetBuilder().ToTable(name);
        }

        /// <summary>
        /// Define a chave primária da entidade.
        /// </summary>
        /// <param name="keyExpression">Empression que determina a chave primária.</param>
        /// <returns>Retorna a configuração da Chave Primária.</returns>
        public KeyBuilder HasKey(Expression<Func<TEntity, object>> keyExpression)
        {
            return GetBuilder().HasKey(keyExpression);
        }

        /// <summary>
        /// Deverá ser implementado com a configuração de Mapeamento da entidade.
        /// </summary>
        public abstract void Configuration();


    }
}
