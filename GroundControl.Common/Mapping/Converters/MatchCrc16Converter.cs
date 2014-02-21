namespace GroundControl.Common.Mapping.Converters
{
    using System.Runtime.Serialization;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;

    [DataContract]
    public class MatchCrc16Converter : Converter
    {
        #region Constructors

        public MatchCrc16Converter()
            : base("MatchCrc16Converter")
        { }

        #endregion

        #region Converter

        public override object Convert(object value, object parameter)
        {
            value.CheckNull("value");
            parameter.CheckNull("parameter");

            var uint16 = (UnsignedInteger16)value;
            var crc16 = (ushort)parameter;
            return (uint16.TypedValue == crc16).ToString();
        }

        #endregion
    }
}
