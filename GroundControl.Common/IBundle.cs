namespace GroundControl.Common
{
    using System;
    using System.Configuration;

    public interface IBundle : IServiceProvider
    {
        string StartupPath { get; }

        string PluginsPath { get; }

        string ConfigurationPath { get; }

        SettingsBase Settings { get; }

        void RegisterService(Type type, object instance);
    }
}
