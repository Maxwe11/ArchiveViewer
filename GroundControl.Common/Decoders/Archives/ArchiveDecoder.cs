namespace GroundControl.Common.Decoders.Archives
{
    using System;
    using System.Data;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;
    using GroundControl.Common.Models.Archives;

    public class ArchiveDecoder : IArchiveDecoder
    {
        #region Fields

        private readonly IArchiveDecoder mDecoder;

        #endregion

        #region Constructor

        internal ArchiveDecoder(ArchiveType type)
        {
            type.CheckNull("type");

            switch (type.DecoderType)
            {
            case ArchiveDecoderType.Complex:
                mDecoder = new ComplexArchiveDecoder(type);
                break;
            case ArchiveDecoderType.CustomSimple:
                mDecoder = new CustomSimpleArchiveDecoder(type);
                break;
            default:
                throw new ArgumentException("Unknown decoder type with value " + (int)type.DecoderType, "type");
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

        public virtual DataTable Template { get { return mDecoder.Template; }}

        #endregion
    }
}
