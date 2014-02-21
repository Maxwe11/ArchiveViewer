namespace GroundControl.Common.Decoders
{
    using System.Collections.Generic;
    using System.Data;
    using System.Xml.Serialization;

    using GroundControl.Common.Decoders.Archives;
    using GroundControl.Common.Helpers;
    using GroundControl.Common.Mapping.Parameters;
    using GroundControl.Common.Properties;

    public class ComplexArchiveDecoder : ArchiveDecoderBase
    {
        #region Fields

        private List<MutableKeyValuePair<byte, List<Parameter>>> mParameters;

        private SortedDictionary<byte, DataTable> mTeplates;

        private const int RecordHeaderBytesCount = 10;

        private const int RecordMetaDataBytesCount = 12;

        #endregion

        #region Properties

        public int DataBytesCount { get; set; }

        [UsedImplicitly]
        [XmlArrayItem("Pair")]
        public List<MutableKeyValuePair<byte, List<Parameter>>> ParametersMap
        {
            get { return mParameters; }
            set
            {
                if (value == null || value == mParameters)
                    return;

                mParameters = value;
            }
        }

        #endregion

        #region ArchiveDecoderBase

        //public override List<ArchiveRecord> Decode(ushort[] data)
//        {
//            data.CheckNull("data");
//
//            if (mTeplates == null)
//                BuildTemplates();
//
//            int bytesPerRecord = RecordMetaDataBytesCount + DataBytesCount;
//            int registersToSkip = 0;
//            int registersPerRecord = bytesPerRecord / sizeof(ushort);
//            int recordsCount = data.Length / registersPerRecord;
//
//            if (bytesPerRecord % sizeof(ushort) != 0)
//                throw new ApplicationException("Parameters with metadata should have even size in bytes");
//
//            var result = new List<ArchiveRecord>(recordsCount);
//            var tmpBuf = new byte[DataBytesCount];
//
//            for (int i = 0; i < recordsCount; ++i, registersToSkip += registersPerRecord)
//            {
//                var recordData = data.Skip(registersToSkip).Take(registersPerRecord - 1).ToArray();
//                var rawCrc16 = data[registersToSkip + registersPerRecord - 1];
//                var crc16Matched = recordData.CalcCrc16() == rawCrc16;
//                var recordId = recordData.GetUInt32();
//                var rawUnixTime = recordData.GetInt32(2);
//                var ss256 = recordData[4].Low();
//                var recordType = recordData[4].Hi();
//
//                var pair = mParameters.FirstOrDefault(x => x.Key == recordType);
//                DataTable dt;
//                if (!mTeplates.TryGetValue(recordType, out dt) || pair == null)
//                {
//                    var msg = "Тип данных записи с значением " + recordType + " не найден";
//                    throw new ApplicationException(msg);
//                }
//
//                Buffer.BlockCopy(recordData, RecordHeaderBytesCount, tmpBuf, 0, tmpBuf.Length);
//                var values = new object[dt.Columns.Count];
//                values[0] = recordId;
//                var reader = new ParametersReaderVisitor(tmpBuf);
//                var parameters = pair.Value;
//                reader.Read(parameters);
//
//                for (int j = 1, k = 0; j < values.Length; ++j, ++k)
//                {
//                    var parameter = parameters[k];
//                    values[j] = parameter.Value;
//
//                    if (parameter.HasConverter)
//                    {
//                        var converter = parameter.Converter;
//                        var converted = converter.Convert(parameter, null, null, null);
//                        values[++j] = converted;
//                    }
//                }
//
//                var record = new ArchiveRecord(recordId, rawUnixTime, ss256, rawCrc16, crc16Matched);
//                dt.Rows.Add(values);
//                result.Add(record);
//            }
//
//            return result;
//        }

        public override ArchiveDecodeResult Decode(ushort[] data, object temp)
        {
            return null;
        }

        #endregion

        #region Methods

        private void BuildTemplates()
        {
            mTeplates =  new SortedDictionary<byte, DataTable>();

            foreach (var pair in mParameters)
            {
                var dt = new DataTable();
                dt.Columns.Add("RecordId", typeof(uint));
                
                foreach (var parameter in pair.Value)
                {
                    var type = parameter.Type;

                    if (parameter.HasConverter)
                    {
                        var displayName = parameter.DisplayName + "(Raw)";
                        dt.Columns.Add(displayName, parameter.Type);
                        type = typeof(string);
                    }

                    dt.Columns.Add(parameter.DisplayName, type);
                }

                mTeplates.Add(pair.Key, dt);
            }
        }

        #endregion
    }
}
