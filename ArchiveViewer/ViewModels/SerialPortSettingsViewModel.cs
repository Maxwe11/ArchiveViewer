﻿namespace ArchiveViewer.ViewModels
{
    using System.IO.Ports;
    using Common.Extensions;

    internal class SerialPortSettingsViewModel
    {
        #region Fields

        private readonly SerialPort mSerialPort;

        #endregion

        #region Constructor

        internal SerialPortSettingsViewModel(SerialPort port)
        {
            port.CheckNull("port");

            mSerialPort = port;
        }

        #endregion

    }
}
