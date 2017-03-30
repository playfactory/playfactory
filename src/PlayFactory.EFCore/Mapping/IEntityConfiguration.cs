using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlayFactory.EFCore.Mapping
{
    /// <summary>
    /// EntityFramework Mapping Configuration Interface.
    /// </summary>
    public interface IEntityConfiguration
    {
        /// <summary>
        ///The EntityFramework Mapping configuration should be implemented.
        /// </summary>
        void Configuration();
        /// <summary>
        /// Method to initialize EntityFramework mapping.
        /// </summary>
        /// <param name="modelBuilder">DbContext ModelBuilder</param>
        /// <returns>Returns the fluent Mapping Configuration interface.</returns>
        IEntityConfiguration Initialize(ModelBuilder modelBuilder);
    }

    /// <summary>
    /// Interface deConfiguração do Mapeamento do EntityFramework.
    /// </summary>
    /// <typeparam name="TEntity">Entity that will be configured.</typeparam>
    public interface IEntityConfiguration<TEntity> : IEntityConfiguration where TEntity : class
    {
        /// <summary>
        /// Mapping of entity property.
        /// </summary>
        /// <typeparam name="TProperty">Type of mapped property.</typeparam>
        /// <param name="propertyExpression">Property definition</param>
        /// <returns>Return property configuration</returns>
        PropertyBuilder<TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression);
        /// <summary>
        /// Sets the name of the table that the entity represents.
        /// </summary>
        /// <param name="name">Table Name.</param>
        /// <returns>Return table configuration.</returns>
        EntityTypeBuilder<TEntity> ToTable(string name);
        /// <summary>
        /// Sets the property that will be the primary key of the table.
        /// </summary>
        /// <param name="keyExpression">Property that represents the primary key.</param>
        /// <returns>Return the configuration of the primary key.</returns>
        KeyBuilder HasKey(Expression<Func<TEntity, object>> keyExpression); 
    }
}
