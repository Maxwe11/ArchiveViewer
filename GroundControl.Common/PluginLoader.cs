namespace GroundControl.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public static class PluginLoader<T>
    {
        public static IEnumerable<T> LoadPlugins(string path, string searchPattern, params object[] args)
        {
            if (!Directory.Exists(path))
                return null;

            var dllFileNames = Directory.GetFiles(path, searchPattern);

            var assemblies = new List<Assembly>(dllFileNames.Length);
            assemblies.AddRange(dllFileNames.Select(AssemblyName.GetAssemblyName)
                                            .Select(Assembly.Load));

            var pluginType = typeof(T);
            var pluginTypes = new List<Type>();
            
            foreach (var assembly in assemblies)
            {
                if (assembly == null)
                    continue;
                
                var types = assembly.GetTypes();
                pluginTypes.AddRange(types.Where(
                    x => x.BaseType == pluginType || x.GetInterface(pluginType.FullName) != null).AsEnumerable());
            }

            var plugins = new List<T>(pluginTypes.Count);
            plugins.AddRange(pluginTypes.Select(type => (T)Activator.CreateInstance(type, args)));

            return plugins;
        }
    }
}
