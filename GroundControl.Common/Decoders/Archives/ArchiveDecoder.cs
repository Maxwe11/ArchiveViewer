namespace GroundControl.Common.Decoders.Archives
{
    using System;
    using System.Linq;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;

    public class ArchiveDecoder : IArchiveDecoder
    {
        #region Fields

        private readonly IArchiveDecoder mDecoder;

        #endregion

        #region Constructor

        internal ArchiveDecoder(ArchiveDecoderType type, ParametersKeyedCollection collection)
        {
            collection.CheckNull("collection");

            switch (type)
            {
            case ArchiveDecoderType.Simple:
                mDecoder = new SimpleArchiveDecoder(collection.First());
                break;
            case ArchiveDecoderType.Complex:
                mDecoder = new ComplexArchiveDecoder(collection);
                break;
            case ArchiveDecoderType.CustomSimple:
                mDecoder = new CustomSimpleArchiveDecoder(collection.First());
                break;
            default:
                throw new ArgumentException("Unknown decoder type with value " + (int)type, "type");

            }
        }

        #endregion

        #region IArchiveDecoder

        public ArchiveDecodeResult Decode(byte[] data)
        {
            return mDecoder.Decode(data);
        }

        public ArchiveDecodeResult Decode(ushort[] data)
        {
            return mDecoder.Decode(data);
        }

        #endregion
    }
}
