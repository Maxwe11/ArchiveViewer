namespace ArchiveViewer.Common.Decoders.Archives
{
    using System.Data;
    using Extensions;

    public class ArchiveDecodeResult
    {
        #region Constructor

        public ArchiveDecodeResult(DataTable data, string errorMessage = null)
        {
            data.CheckNull("data");

            Data = data;
            ErrorMessage = errorMessage;
        }

        #endregion

        #region Properties

        public DataTable Data { get; private set; }

        public string ErrorMessage { get; private set; }

        public bool IsFailed { get { return ErrorMessage != null; } }

        #endregion
    }
}
