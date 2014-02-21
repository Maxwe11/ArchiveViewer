namespace GroundControl.Common.Decoders.Archives
{
    using System;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;

    internal class SimpleArchiveDecoder : IArchiveDecoder
    {
        #region Fields

        private readonly ParametersCollection mParameters;

        #endregion

        #region Constructor

        internal SimpleArchiveDecoder(ParametersCollection collection)
        {
            collection.CheckNull("collection");

            mParameters = collection;
        }

        #endregion

        #region IArchiveDecoder

        public ArchiveDecodeResult Decode(byte[] data)
        {
            throw new NotImplementedException();
        }

        public ArchiveDecodeResult Decode(ushort[] data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
