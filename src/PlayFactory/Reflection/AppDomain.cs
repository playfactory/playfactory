using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace PlayFactory.Reflection
{
    /// <summary>
    /// Esta classe possui métodos úteis para trabalhar com Refletion.
    /// </summary>
    public class AppDomain
    {
        public static Assembly[] GetAssemblies()
        {
            return GetAssemblies(null);
        }

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

        private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary)
        {
            return compilationLibrary.Type == "project"
                || compilationLibrary.Dependencies.Any(d => d.Name.StartsWith("PlayFactory"));
        }
    }
}
