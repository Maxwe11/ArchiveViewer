namespace GroundControl.Common.Helpers
{
    using GroundControl.Common.Extensions;
    using GroundControl.Common.Services;

    public sealed class SerialPortBlocker : Blockable
    {
        #region Fields

        private readonly ISerialPortService mService;

        #endregion

        #region Constructor

        public SerialPortBlocker(ISerialPortService service)
        {
            service.CheckNull("service");
            
            mService = service;

            Block();
        }

        #endregion

        #region Blockable

        protected override void Block()
        {
            if (!mService.IsOpen)
                mService.Open();
        }

        protected override void Unblock()
        {
            if (mService.IsOpen)
                mService.Close();
        }

        #endregion
    }
}
