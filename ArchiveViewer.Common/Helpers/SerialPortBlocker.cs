namespace ArchiveViewer.Common.Helpers
{
    using Extensions;
    using Services;

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
