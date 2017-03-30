using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace PlayFactory.Reflection
{
    /// <summary>
    /// This class has useful methods for working with Reflection.
    /// </summary>
    public class AppDomain
    {
        /// <summary>
        /// Returns all Assemblies of the application.
        /// </summary>
        /// <returns>Returns the list of solution assemblies.</returns>
        public static Assembly[] GetAssemblies()
        {
            return GetAssemblies(null);
        }

        /// <summary>
        /// Returns all Assemblies and executes the action passed by parameter when each assembly is encountered.
        /// </summary>
        /// <param name="action">Action that will be performed upon finding the Assembly.</param>
        /// <returns>Returns the list of solution assemblies.</returns>
        public static Assembly[] GetAssemblies(Action<Assembly> action)
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (!IsCandidateCompilationLibrary(library))
                    continue;

                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);

                action?.Invoke(assembly);
            }
            return assemblies.ToArray();
        }

        /// <summary>
        /// Checks whether the RuntimeLibrary belongs to Solution or is a third-party library.
        /// </summary>
        /// <param name="compilationLibrary">CompilationLibrary to be checked the type.</param>
        /// <returns>Returns whether the RuntimeLibrary belongs to the solution.</returns>
        private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary)
        {
            return compilationLibrary.Type == "project"
                || compilationLibrary.Dependencies.Any(d => d.Name.StartsWith("PlayFactory"));
        }
    }
}
