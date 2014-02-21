namespace GroundControl.Common.Mapping.Converters
{
    using System.Runtime.Serialization;
    using System.Text;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;

    [DataContract]
    public class BitsToStringConverter : Converter
    {
        #region Constructor

        public BitsToStringConverter(string name)
            : base(name)
        {
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

            var integer = (Integer32)value;
            var typedValue = integer.TypedValue;
            var builder = new StringBuilder(500);

            builder.AppendFormat("{0}: ", typedValue);
            foreach (var bitPair in Collection)
            {
                if ((typedValue & (1 << bitPair.First)) != 0)
                    builder.AppendLine(bitPair.Second);
            }

            return builder.ToString();
        }

        #endregion
    }
}
