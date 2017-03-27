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
    /// DbContext Base para o PLayFactory.
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
        /// Método responsável por carregar as classes EntityTypeConfiguration com as definições de mapeamentos.
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
