namespace GroundControl.Common.Decoders.Archives
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Converters;
    using GroundControl.Common.Mapping.Parameters;
    using GroundControl.Common.Mapping.Visitors;
    using GroundControl.Common.Models.Archives;

    internal class ComplexArchiveDecoder : IArchiveDecoder
    {
        #region Fields

        private readonly ArchiveType mArchive;

        private readonly ParametersKeyedCollection mKeyedParameters;

        private readonly SortedDictionary<byte, int> mCollectionIdIndex = new SortedDictionary<byte, int>();

        private readonly ToUnixTimeConverter mToUnixTimeConverter = new ToUnixTimeConverter();

        #endregion

        #region Constructor

        internal ComplexArchiveDecoder(ArchiveType type)
        {
            type.CheckNull("type");

            var @params = type.Parameters;

            if (@params.Count == 1 && !@params[0].CollectionId.HasValue)
                throw new ArgumentException("archive should have collection with id", "type");
                
            mArchive = type;
            mKeyedParameters = @params;
            BuildTemplate();
        }

        #endregion

        #region Methods

        private void BuildTemplate()
        {
            if (Template == null)
            {
                Template = new DataTable();
            }
            else
            {
                Template.Columns.Clear();
                Template.Clear();
            }

            Template.Columns.Add("RecordId", typeof(uint));
            Template.Columns.Add("RawUnixTime", typeof(int));
            Template.Columns.Add("UnixTime", typeof(string));
            Template.Columns.Add("Ss256", typeof(byte));
            Template.Columns.Add("RawCrc16", typeof(ushort));
            Template.Columns.Add("Crc16Matched", typeof(bool));
            Template.Columns.Add("RecordType", typeof(byte));

            mCollectionIdIndex.Clear();

            foreach (var collection in mKeyedParameters.OrderBy(x => x.CollectionId))
            {
                mCollectionIdIndex.Add(collection.CollectionId.Value, Template.Columns.Count);

                for (int i = 0; i < collection.Count; ++i)
                {
                    var parameter = collection[i];
                    var displayName = parameter.DisplayName;
                    var type = parameter.Type;

                    if (parameter.HasConverter)
                    {
                        Template.Columns.Add(displayName + "(Raw)", type);
                        Template.Columns.Add(displayName, typeof(string));
                    }
                    else
                    {
                        Template.Columns.Add(displayName, type);
                    }
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

            var tmpBuf = new byte[parametersBytesCount];

            for (int i = 0; i < recordsCount; ++i, registersToSkip += registersPerRecord)
            {
                var recordData = data.Skip(registersToSkip).Take(registersPerRecord - 1).ToArray();
                var rawCrc16 = data[registersToSkip + registersPerRecord - 1];
                var crc16Matched = recordData.CalcCrc16() == rawCrc16;
                var recordId = recordData.GetUInt32();
                var rawUnixTime = recordData.GetInt32(2);
                var ss256 = recordData[4].Low();
                var recordType = recordData[4].Hi();

                Buffer.BlockCopy(recordData, recordHeaderBytesCount, tmpBuf, 0, tmpBuf.Length);
                var values = new object[Template.Columns.Count];
                values[0] = recordId;
                values[1] = rawUnixTime;
                values[2] = mToUnixTimeConverter.Convert(rawUnixTime, null);
                values[3] = ss256;
                values[4] = rawCrc16;
                values[5] = crc16Matched;
                values[6] = recordType;

                var parameters = mKeyedParameters.FirstOrDefault(x => x.CollectionId == recordType);
                int jIndex;
                
                if (parameters == null)
                {
                    dt.Rows.Add(values);
                    continue;
                }
                
                var findIdResult = mCollectionIdIndex.TryGetValue(parameters.CollectionId.Value, out jIndex);
                if (!findIdResult)
                {
                    dt.Rows.Add(values);
                    continue;
                }

                var reader = new ParametersReaderVisitor(tmpBuf);
                reader.Read(parameters);

                for (int j = jIndex, k = 0; k < parameters.Count; ++j, ++k)
                {
                    var parameter = parameters[k];
                    values[j] = parameter.Value;

                    if (parameter.HasConverter)
                    {
                        var converter = parameter.Converter;
                        var converted = converter.Convert(parameter.Value, null);
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
