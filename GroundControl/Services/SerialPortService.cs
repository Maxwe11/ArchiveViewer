namespace GroundControl.Services
{
    using System.ComponentModel;
    using System.IO.Ports;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Properties;
    using GroundControl.Common.Services;

    internal sealed class SerialPortService : ISerialPortService
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

        public void Open()
        {
            mPort.Open();
            OnPropertyChanged("IsOpen");
        }

        public void Close()
        {
            mPort.Close();
            OnPropertyChanged("IsOpen");
        }

        public bool IsOpen { get { return mPort.IsOpen; } }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
