namespace GroundControl.Common.Decoders
{
    using System.Collections.Generic;
    using System.Data;

    using GroundControl.Common.Decoders.Archives;
    using GroundControl.Common.Mapping.Parameters;
    using GroundControl.Common.Properties;

    public class EventsArchiveDecoder : ArchiveDecoderBase
    {
        #region Fields

        private List<Parameter> mParameters;

        private const string EventIdParameterName = "EventId";

        private const int RecordHeaderBytesCount = 9;

        private const int RecordMetaDataBytesCount = 11;

        private DataTable mTemplate;

        #endregion

        #region Properties

        [UsedImplicitly]
        public List<Parameter> Parameters
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

//        public override List<ArchiveRecord> Decode(ushort[] data)
//        {
//            data.CheckNull("data");
//
//            if (mTemplate == null)
//                BuildTemplate();
//            
//            int bytesPerRecord = RecordMetaDataBytesCount + Parameters.BytesCount;
//            int registersToSkip = 0;
//            int registersPerRecord = bytesPerRecord / sizeof(ushort);
//            int recordsCount = data.Length / registersPerRecord;
//
//            if (bytesPerRecord % sizeof(ushort) != 0)
//                throw new ApplicationException("Parameters with metadata should have even size in bytes");
//
//            var result = new List<ArchiveRecord>(recordsCount);
//            var tmpBuf = new byte[Parameters.BytesCount];
//
//            for (int i = 0; i < recordsCount; ++i, registersToSkip += registersPerRecord)
//            {
//                var recordData = data.Skip(registersToSkip).Take(registersPerRecord - 1).ToArray();
//                var rawCrc16 = data[registersToSkip + registersPerRecord - 1];
//                var crc16Matched = recordData.CalcCrc16() == rawCrc16;
//                var recordId = recordData.GetUInt32();
//                var rawUnixTime = recordData.GetInt32(2);
//                var ss256 = recordData[4].Low();
//
//                Buffer.BlockCopy(recordData, RecordHeaderBytesCount, tmpBuf, 0, tmpBuf.Length);
//                var values = new object[mTemplate.Columns.Count];
//                var reader = new ParametersReaderVisitor(tmpBuf);
//                reader.Read(Parameters);
//
//                for (int j = 0, k = 0; j < values.Length; ++j, ++k)
//                {
//                    var parameter = Parameters[k];
//                    values[j] = parameter.Value;
//
//                    if (parameter.HasConverter)
//                    {
//                        var converter = parameter.Converter;
//                        var converted = converter.Convert(parameter, null, null, null);
//
//                        if (parameter.Name == EventIdParameterName)
//                        {
//                            var pair = (MutableKeyValuePair<string, Converter>)converted;
//                            values[++j] = pair.Key;
//                            var eventDataParameter = Parameters[++k];
//                            values[++j] = pair.Value.Convert(eventDataParameter, null, null, null);
//                        }
//                        else
//                        {
//                            values[++j] = converted;
//                        }
//                    }
//                }
//
//                var record = new ArchiveRecord(recordId, rawUnixTime, ss256, rawCrc16, crc16Matched);
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

        private void BuildTemplate()
        {
            mTemplate = new DataTable();
            mTemplate.Columns.Add("RecordId", typeof(uint));
            
            for (int i = 0; i < mParameters.Count; ++i)
            {
                var parameter = mParameters[i];

                if (parameter.Name != EventIdParameterName)
                {
                    var type = parameter.Type;

                    if (parameter.HasConverter)
                    {
                        var displayName = parameter.DisplayName + "(Raw)";
                        mTemplate.Columns.Add(displayName, parameter.Type);
                        type = typeof(string);
                    }

                    mTemplate.Columns.Add(parameter.DisplayName, type);
                    continue;
                }

                var dispName = parameter.DisplayName + "(Raw)";
                mTemplate.Columns.Add(dispName, parameter.Type);
                mTemplate.Columns.Add(parameter.DisplayName, typeof(string));
                parameter = mParameters[++i];
                mTemplate.Columns.Add(parameter.DisplayName, typeof(string));
            }
        }

        #endregion
    }
}
