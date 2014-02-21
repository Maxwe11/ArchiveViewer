namespace GroundControl.Common.Services
{
    public interface ISerialPortService
    {
        void Open();

        void Close();

        bool IsOpen { get; }
    }
}
