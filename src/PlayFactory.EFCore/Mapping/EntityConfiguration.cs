using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlayFactory.EFCore.Mapping
{
    /// <summary>
    /// Base class for entity mapping classes.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityConfiguration<TEntity> : IEntityConfiguration<TEntity> where TEntity : class
    {
        private EntityTypeBuilder<TEntity> _builder;

        /// <summary>
        /// Returns the EntityTypeBuilder.
        /// </summary>
        /// <returns>EntityTypeBuilder</returns>
        protected EntityTypeBuilder<TEntity> GetBuilder()
        {
            if (_builder == null)
                throw new Exception("Initialize did not run");

            return _builder;
        }

        /// <summary>
        /// Class that will be executed when the EntityConfiguration configuration is initialized
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public IEntityConfiguration Initialize(ModelBuilder modelBuilder)
        {
            _builder = modelBuilder.Entity<TEntity>();
            return this;
        }

        /// <summary>
        /// Setting the Property.
        /// </summary>
        /// <typeparam name="TProperty">Type of Property.</typeparam>
        /// <param name="propertyExpression">An expression that defines the mapped property.</param>
        /// <returns>Returns a PropertyBuilder for property configuration.</returns>
        public PropertyBuilder<TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            return GetBuilder().Property(propertyExpression);
        }

        /// <summary>
        /// Sets the name of the table.
        /// </summary>
        /// <param name="name">Table Name</param>
        /// <returns>Returns the EntityTypeBuilder with the table configuration.</returns>
        public EntityTypeBuilder<TEntity> ToTable(string name)
        {
            return GetBuilder().ToTable(name);
        }

        /// <summary>
        /// Defines the primary key of the entity.
        /// </summary>
        /// <param name="keyExpression">Expression that determines the primary key.</param>
        /// <returns>Return the Primary Key configuration.</returns>
        public KeyBuilder HasKey(Expression<Func<TEntity, object>> keyExpression)
        {
            return GetBuilder().HasKey(keyExpression);
        }

        /// <summary>
        /// It should be implemented with the Entity Mapping setting.
        /// </summary>
        public abstract void Configuration();


    }
}
