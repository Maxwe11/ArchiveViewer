namespace GroundControl.Common.Decoders.Archives
{
    using System;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;

    internal class ComplexArchiveDecoder : IArchiveDecoder
    {
        #region Fields

        private readonly ParametersKeyedCollection mKeyedParameters;

        #endregion

        #region Constructor

        internal ComplexArchiveDecoder(ParametersKeyedCollection collection)
        {
            collection.CheckNull("collection");

            mKeyedParameters = collection;
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
