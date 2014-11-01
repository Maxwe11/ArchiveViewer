namespace ArchiveViewer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;

    internal class SerialPortInfo
    {
        #region Properties

        internal string Name { get; private set; }

        internal string FriendlyName { get; private set; }

        #endregion

        #region Constructor

        internal SerialPortInfo(string name, string friendlyName)
        {
            Name = name;
            FriendlyName = friendlyName;
        }

        #endregion

        #region Methods

        internal static List<SerialPortInfo> GetSerialPortsInfo()
        {
            var serialPortInfoList = new List<SerialPortInfo>();
            var options = ProcessConnection.ProcessConnectionOptions();
            var connectionScope = ProcessConnection.ConnectionScope(Environment.MachineName, options, @"\root\CIMV2");
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0");
            var comPortSearcher = new ManagementObjectSearcher(connectionScope, objectQuery);

            using (comPortSearcher)
            {
                var list = comPortSearcher.Get();
                serialPortInfoList.AddRange(from ManagementObject obj in list 
                                            where obj != null 
                                            select obj["Caption"] into captionObj 
                                            where captionObj != null 
                                            select captionObj.ToString() into caption 
                                            let index = caption.LastIndexOf("(COM", StringComparison.Ordinal) 
                                            where index != -1 
                                            let name = caption.Substring(index).Replace("(", "").Replace(")", "") 
                                            let friendlyName = caption 
                                            select new SerialPortInfo(name, friendlyName));
            }

            return serialPortInfoList;
        }

        #endregion
    }
}
