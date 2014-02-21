namespace GroundControl.Common.Decoders
{
    using System.Data;
    using System.Xml.Serialization;

    using GroundControl.Common.Decoders.Archives;

    [XmlInclude(typeof(EventsArchiveDecoder))]
    [XmlInclude(typeof(ComplexArchiveDecoder))]
    public abstract class ArchiveDecoderBase
    {
        #region Constructor

        protected ArchiveDecoderBase()
        {
            Template = new DataTable();
            Template.Columns.Add("RecordId", typeof(uint));
            Template.Columns.Add("RawUnixTime", typeof(int));
            Template.Columns.Add("UnixTime", typeof(string));
            Template.Columns.Add("Ss256", typeof(byte));
            Template.Columns.Add("RawCrc16", typeof(ushort));
            Template.Columns.Add("Crc16Matched", typeof(bool));
        }

        #endregion

        #region Properties

        [XmlIgnore]
        public DataTable Template { get; protected set; }

        #endregion

        #region Methods

        //public abstract List<ArchiveRecord> Decode(ushort[] data);

        public abstract ArchiveDecodeResult Decode(ushort[] data, object temp);

        #endregion
    }
}
