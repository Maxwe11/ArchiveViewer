namespace GroundControl.Common.Services
{
    using System.ComponentModel;

    public interface ISerialPortService : INotifyPropertyChanged
    {
        void Open();

        void Close();

        bool IsOpen { get; }
    }
}
