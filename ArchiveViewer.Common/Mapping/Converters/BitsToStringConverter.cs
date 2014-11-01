namespace ArchiveViewer.Common.Mapping.Converters
{
    using System.Runtime.Serialization;
    using System.Text;
    using Extensions;

    [DataContract]
    public class BitsToStringConverter : Converter
    {
        #region Constructor

        public BitsToStringConverter(string name)
            : base(name)
        {
            Collection = new KeyValuePairsCollection<byte, string>();
        }

        #endregion

        #region Properties

        [DataMember(IsRequired = true, Order = 1)]
        public KeyValuePairsCollection<byte, string> Collection { get; private set; }

        #endregion

        #region Converter

        public override object Convert(object value, object parameter)
        {
            value.CheckNull("value");

            var integer = (int)value;
            var builder = new StringBuilder(500);

            builder.AppendFormat("0x{0:X}: ", integer);
            foreach (var bitPair in Collection)
            {
                if ((integer & (1 << bitPair.First)) != 0)
                    builder.AppendLine(bitPair.Second);
            }

            return builder.ToString();
        }

        #endregion
    }
}
