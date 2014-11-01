namespace ArchiveViewer.Common.Extensions
{
    using System.Configuration;
    using System.IO.Ports;

    public static class SerialPortEx
    {
        public static void SetUpPortFromSettings(this SerialPort port, SettingsBase settings)
        {
            port.CheckNull("port");
            settings.CheckNull("settings");

            port.PortName = (string)settings["PortName"];
            port.BaudRate = (int)settings["BaudRate"];
            port.Parity = (Parity)settings["Parity"];
            port.DataBits = (int)settings["DataBits"];
            port.StopBits = (StopBits)settings["StopBits"];
            port.Handshake = (Handshake)settings["Handshake"];
            port.ReadTimeout = (int)settings["ReadTimeout"];
            port.WriteTimeout = (int)settings["ReadTimeout"];
        }
    }
}
