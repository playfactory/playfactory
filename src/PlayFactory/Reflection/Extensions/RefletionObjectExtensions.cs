using System;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace PlayFactory.Reflection.Extensions
{
    /// <summary>
    /// Class Helper para Assembly e Type.
    /// </summary>
    public static class RefletionObjectExtensions
    {
        /// <summary>
        /// Retorna o Assembly que a classe do objeto pertence.
        /// </summary>
        /// <param name="obj">Objeto Help</param>
        /// <returns>Assembly da classe do objeto.</returns>
        public static Assembly GetExecutingAssembly(this object obj)
        {
            var type = obj.GetType();
            var assembly = type.GetTypeInfo().Assembly;
            return assembly;
        }

        /// <summary>
        /// Retorna o Assembly que o Type está sendo executado.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="action">Para cada assembly que for encontrado será retornado como parâmetro para a Action.</param>
        /// <param name="typesAssembly">Define o Type do Assembly que será filtrado.</param>
        public static void GetExecutingAssembly(this Type type, Action<Assembly> action, string typesAssembly = "project")
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var deps = DependencyContext.Default;

            foreach (var compilationLibrary in deps.CompileLibraries)
            {
                if (compilationLibrary.Type != "project")
                    continue;

                var assembly = Assembly.Load(new AssemblyName(compilationLibrary.Name));

                action(assembly);
            }
        }
    }
}
