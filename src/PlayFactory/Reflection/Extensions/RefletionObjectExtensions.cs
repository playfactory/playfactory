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
    }
}
