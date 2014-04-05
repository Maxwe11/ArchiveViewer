namespace GroundControl.Common.Models.Archives
{
    using System.Runtime.Serialization;

    using GroundControl.Common.Decoders.Archives;
    using GroundControl.Common.Mapping.Parameters;

    [DataContract]
    public class ArchiveType
    {
        #region Fields

        public const ushort EraseOpCodeCommand = 0xA5A5;

        private ArchiveDecoder mDecoder;

        #endregion

        #region Constructor

        public ArchiveType(int id, string displayName, byte slaveId, ushort cmdRegAdr, ushort recordRegsCount, ushort recordsCount, ArchiveDecoderType type, byte metadataSize, ParametersKeyedCollection parameters)
        {
            Id = id;
            DisplayName = displayName;
            SlaveId = slaveId;
            CommandRegister = cmdRegAdr;
            RecordRegistersCount = recordRegsCount;
            RecordsCount = recordsCount;
            DecoderType = type;
            RecordMetaDataBytesCount = metadataSize;
            Parameters = parameters;
        }

        #endregion

        #region Properties

        [DataMember(IsRequired = true, Order = 0)]
        public int Id { get; private set; }

        [DataMember(IsRequired = true, Order = 1)]
        public string DisplayName { get; private set; }

        [DataMember(IsRequired = true, Order = 2)]
        public byte SlaveId { get; private set; }

        [DataMember(IsRequired = true, Order = 3)]
        public ushort CommandRegister { get; private set; }

        public ushort PositionRegister { get { return (ushort)(CommandRegister + 1); } }

        public ushort DataRegister { get { return (ushort)(CommandRegister + 2); } }

        [DataMember(IsRequired = true, Order = 4)]
        public ushort RecordRegistersCount { get; private set; }

        [DataMember(IsRequired = true, Order = 5)]
        public ushort RecordsCount { get; private set; }

        [DataMember(IsRequired = true, Order = 6)]
        public ArchiveDecoderType DecoderType { get; private set; }

        [DataMember(IsRequired = true, Order = 7)]
        public byte RecordMetaDataBytesCount { get; private set; }

        [DataMember(IsRequired = true, Order = 8)]
        public ParametersKeyedCollection Parameters { get; private set; }

        public ArchiveDecoder Decoder { get { return mDecoder ?? (mDecoder = new ArchiveDecoder(this)); } }

        #endregion
    }
}
