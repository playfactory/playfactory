using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace PlayFactory.Reflection
{
    public class AppDomain
    {
        public static AppDomain CurrentDomain { get; private set; }

        static AppDomain()
        {
            CurrentDomain = new AppDomain();
        }

        public Assembly[] GetAssemblies()
        {
            return GetAssemblies(null);
        }

        public Assembly[] GetAssemblies(Action<Assembly> action)
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
            return compilationLibrary.Name == ("Specify")
                || compilationLibrary.Dependencies.Any(d => d.Name.StartsWith("Specify"));
        }
    }
}
