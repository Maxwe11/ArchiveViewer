namespace GroundControl
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;

    using GroundControl.Common;
    using GroundControl.Common.Extensions;
    using GroundControl.Common.Services;

    internal sealed class AppBundle : IBundle
    {
        #region Fields

        private readonly Dictionary<Type, object> mServices = new Dictionary<Type, object>();

        #endregion

        #region Constructors

        internal AppBundle(string startupPath, SettingsBase settings)
        {
            startupPath.CheckNull("startupPath");
            settings.CheckNull("settings");

            StartupPath = startupPath;
            PluginsPath = Path.Combine(StartupPath, "plugins");
            ConfigurationPath = Path.Combine(StartupPath, "config");
            Settings = settings;
        }

        #endregion

        #region IServiceProvider

        public object GetService(Type serviceType)
        {
            serviceType.CheckNull("serviceType");
            object result;

            if (mServices.TryGetValue(serviceType, out result))
                return result;

            throw new ServiceNotFoundException(serviceType.FullName);
        }

        #endregion

        #region IBundle

        public string StartupPath { get; private set; }

        public string PluginsPath { get; private set; }

        public string ConfigurationPath { get; private set; }

        public SettingsBase Settings { get; private set; }

        public void RegisterService(Type type, object instance)
        {
            mServices.Add(type, instance);
        }

        #endregion
    }
}
