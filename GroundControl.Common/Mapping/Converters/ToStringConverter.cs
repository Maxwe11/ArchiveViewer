namespace GroundControl.Common.Mapping.Converters
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class ToStringConverter<T> : Converter
    {
        #region Constructor

        public ToStringConverter(string name)
            : base(name)
        {
            Collection = new KeyValuePairsCollection<T, string>();
        }

        #endregion

        #region Properties

        [DataMember(IsRequired = true, Order = 1)]
        public KeyValuePairsCollection<T, string> Collection { get; private set; }

        #endregion

        #region Converter

        public override object Convert(object value, object parameter)
        {
            T key = (T)value;

            try
            {
                var str = Collection[key];
                return str;
            }
            catch (Exception)
            {
            }

            return key + ": Unknown";
        }

        #endregion
    }
}
