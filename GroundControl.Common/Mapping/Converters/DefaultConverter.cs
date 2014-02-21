namespace GroundControl.Common.Mapping.Converters
{
    using System.Runtime.Serialization;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;

    [DataContract]
    public class DefaultConverter : Converter
    {
        #region Constructors

        public DefaultConverter()
            : base("DefaultConverter")
        { }

        #endregion

        #region Converter

        public override object Convert(object value, object parameter)
        {
            value.CheckNull("value");

            var param = value as Parameter;

            return param == null ? value.ToString() : param.Value.ToString();
        }

        #endregion
    }
}
