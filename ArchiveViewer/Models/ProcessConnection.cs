namespace ArchiveViewer.Models
{
    using System.Management;
    using Common.Extensions;

    internal static class ProcessConnection
    {
        public static ConnectionOptions ProcessConnectionOptions()
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Authentication = AuthenticationLevel.Default,
                EnablePrivileges = true
            };

            return options;
        }

        public static ManagementScope ConnectionScope(string machineName, ConnectionOptions options, string path)
        {
            machineName.CheckNull("machineName");
            options.CheckNull("options");
            path.CheckNull("path");

            var connectScope = new ManagementScope
            {
                Path = new ManagementPath(@"\\" + machineName + path),
                Options = options
            };

            connectScope.Connect();
            return connectScope;
        }
    }
}
