using System;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace PlayFactory.Reflection.Extensions
{
    /// <summary>
    /// Class Helper for Assembly and Type.
    /// </summary>
    public static class RefletionObjectExtensions
    {
        /// <summary>
        /// Returns the Assembly that the class of the object belongs to.
        /// </summary>
        /// <param name="obj">Help Object</param>
        /// <returns>Assembly of the object class.</returns>
        public static Assembly GetExecutingAssembly(this object obj)
        {
            var type = obj.GetType();
            var assembly = type.GetTypeInfo().Assembly;
            return assembly;
        }
    }
}
