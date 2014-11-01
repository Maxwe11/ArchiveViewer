namespace ArchiveViewer.Common.Services
{
    using System;

    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException(string serviceName)
            : base("Service with name \"" + serviceName + "\" not found")
        { }
    }
}
