namespace ArchiveViewer.Common.Mapping.Converters
{
    using System.Globalization;
    using Extensions;

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

            var integer = (int)value;

            try
            {
                var dt = integer.ToUnixDateTime();
                return dt.ToString("dd.MM.yyyy HH:mm:ss");
            }
            catch
            {
            }

            return integer.ToString(CultureInfo.InvariantCulture);
        }

        #endregion
    }
}
