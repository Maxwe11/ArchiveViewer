namespace GroundControl.Common.Decoders.Archives
{
    using System;
    using System.Data;
    using System.Linq;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Converters;
    using GroundControl.Common.Mapping.Parameters;
    using GroundControl.Common.Mapping.Visitors;
    using GroundControl.Common.Models.Archives;

    internal class CustomSimpleArchiveDecoder : IArchiveDecoder
    {
        #region Fields

        private readonly ArchiveType mArchive;

        private readonly ParametersCollection mParameters;

        private readonly ToUnixTimeConverter mToUnixTimeConverter = new ToUnixTimeConverter();

        #endregion

        #region Constructors

        internal CustomSimpleArchiveDecoder(ArchiveType type)
        {
            type.CheckNull("type");

            mArchive = type;
            mParameters = type.Parameters.First();
            BuildTemplate();
        }

        #endregion

        #region Methods

        private void BuildTemplate()
        {
            Template = new DataTable();
            Template.Columns.Add("RecordId", typeof(uint));
            Template.Columns.Add("RawUnixTime", typeof(int));
            Template.Columns.Add("UnixTime", typeof(string));
            Template.Columns.Add("Ss256", typeof(byte));
            Template.Columns.Add("RawCrc16", typeof(ushort));
            Template.Columns.Add("Crc16Matched", typeof(bool));

            for (int i = 0; i < mParameters.Count; ++i)
            {
                var parameter = mParameters[i];
                var displayName = parameter.DisplayName;
                var type = parameter.Type;

                if (parameter.HasConverter)
                {
                    var converter = parameter.Converter;

                    Template.Columns.Add(displayName + "(Raw)", type);
                    Template.Columns.Add(displayName, typeof(string));

                    if (!converter.GetType().Name.StartsWith("ToStringConverterPairConverter"))
                        continue;

                    parameter = mParameters[++i];
                    displayName = parameter.DisplayName;
                    type = parameter.Type;

                    Template.Columns.Add(displayName + "(Raw)", type);
                    Template.Columns.Add(displayName, typeof(string));
                }
                else
                {
                    Template.Columns.Add(displayName, type);
                }
            }
        }

        #endregion

        #region IArchiveDecoder

        public ArchiveDecodeResult Decode(byte[] data)
        {
            throw new NotImplementedException();
        }

        public ArchiveDecodeResult Decode(ushort[] data)
        {
            data.CheckNull("data");

            var dt = Template.Clone();

            int parametersBytesCount = mArchive.RecordRegistersCount * sizeof(ushort) - mArchive.RecordMetaDataBytesCount;
            int bytesPerRecord = mArchive.RecordMetaDataBytesCount + parametersBytesCount;
            int registersToSkip = 0;
            int registersPerRecord = bytesPerRecord / sizeof(ushort);
            int recordsCount = data.Length / registersPerRecord;
            int recordHeaderBytesCount = mArchive.RecordMetaDataBytesCount - sizeof(ushort);

            //if (bytesPerRecord % sizeof(ushort) != 0)
            //    throw new ApplicationException("Parameters with metadata should have even size in bytes");
            
            var tmpBuf = new byte[parametersBytesCount];
            
            for (int i = 0; i < recordsCount; ++i, registersToSkip += registersPerRecord)
            {
                var recordData = data.Skip(registersToSkip).Take(registersPerRecord - 1).ToArray();
                var rawCrc16 = data[registersToSkip + registersPerRecord - 1];
                var crc16Matched = recordData.CalcCrc16() == rawCrc16;
                var recordId = recordData.GetUInt32();
                var rawUnixTime = recordData.GetInt32(2);
                var ss256 = recordData[4].Low();
            
                Buffer.BlockCopy(recordData, recordHeaderBytesCount, tmpBuf, 0, tmpBuf.Length);
                var values = new object[Template.Columns.Count];
                values[0] = recordId;
                values[1] = rawUnixTime;
                values[2] = mToUnixTimeConverter.Convert(rawUnixTime, null);
                values[3] = ss256;
                values[4] = rawCrc16;
                values[5] = crc16Matched;
                
                var reader = new ParametersReaderVisitor(tmpBuf);
                reader.Read(mParameters);
            
                for (int j = 6, k = 0; k < mParameters.Count; ++j, ++k)
                {
                    var parameter = mParameters[k];
                    values[j] = parameter.Value;

                    if (parameter.HasConverter)
                    {
                        var converter = parameter.Converter;
                        var converted = converter.Convert(parameter.Value, null);

                        if (converter.GetType().Name.StartsWith("ToStringConverterPairConverter"))
                        {
                            var pair = (StringConverterPair)converted;
                            values[++j] = pair.Text;

                            parameter = mParameters[++k];                           
                            converter = ConvertersCollection.Instance()[pair.ConverterName];
                            converted = converter.Convert(parameter.Value, null);
                            
                            values[++j] = parameter.Value;
                        }

                        values[++j] = converted;
                    }
                }

                dt.Rows.Add(values);
            }

            return new ArchiveDecodeResult(dt);
        }

        public DataTable Template { get; private set; }

        #endregion
    }
}
