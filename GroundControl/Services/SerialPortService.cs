namespace GroundControl.Services
{
    using System.IO.Ports;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Services;

    internal class SerialPortService : ISerialPortService
    {
        #region Fields

        private readonly SerialPort mPort;

        #endregion

        #region Constructor

        internal SerialPortService(SerialPort port)
        {
            port.CheckNull("port");

            mPort = port;
        }

        #endregion

        #region ISerialPortService

        void ISerialPortService.Open()
        {
            mPort.Open();
        }

        void ISerialPortService.Close()
        {
            mPort.Close();
        }

        bool ISerialPortService.IsOpen { get { return mPort.IsOpen; } }

        #endregion
    }
}
