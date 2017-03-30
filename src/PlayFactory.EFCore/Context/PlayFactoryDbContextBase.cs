using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PlayFactory.EFCore.Mapping;
using PlayFactory.Reflection;
using PlayFactory.Reflection.Extensions;

namespace PlayFactory.EFCore.Context
{
    /// <summary>
    /// DbContext Base for PlayFactory.
    /// </summary>
    public class PlayFactoryDbContextBase : DbContext
    {
        public PlayFactoryDbContextBase(DbContextOptions options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LoadEntityTypeConfigurarion(modelBuilder);
        }

        /// <summary>
        /// Method responsible for loading the EntityTypeConfiguration classes with the mappings definitions.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected void LoadEntityTypeConfigurarion(ModelBuilder modelBuilder)
        {
            var type = typeof(IEntityConfiguration);
            var typeIsNot = new[] { type, typeof(IEntityConfiguration<>), typeof(EntityConfiguration<>) };

            AppDomain.GetAssemblies(assembly => 
            {
                var entityTypes = assembly.GetTypes().Where(t => t != type && type.IsAssignableFrom(t) && !typeIsNot.Contains(t))
                                .Select(t => (IEntityConfiguration)Activator.CreateInstance(t)).ToList();

                foreach(var entityType in entityTypes)
                {
                    entityType
                        .Initialize(modelBuilder)
                        .Configuration();
                }
            });
        }
    }
}
