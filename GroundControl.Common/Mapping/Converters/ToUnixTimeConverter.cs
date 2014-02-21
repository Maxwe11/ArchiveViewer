namespace GroundControl.Common.Mapping.Converters
{
    using System.Globalization;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;

    public class ToUnixTimeConverter : Converter
    {
        #region Constructors

        public ToUnixTimeConverter()
            : base("ToUnixTimeConverter")
        { }

        #endregion

        #region Converter

        public override object Convert(object value, object parameter)
        {
            value.CheckNull("value");

            var integer = (Integer32)value;

            try
            {
                var dt = integer.TypedValue.ToUnixDateTime();
                return dt.ToString("dd.MM.yyyy HH:mm:ss");
            }
            catch
            {
            }

            return integer.TypedValue.ToString(CultureInfo.InvariantCulture);
        }

        #endregion
    }
}
