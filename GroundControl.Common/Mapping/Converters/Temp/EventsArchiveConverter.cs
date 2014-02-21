namespace GroundControl.Common.Mapping.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Serialization;

    using GroundControl.Common.Helpers;
    using GroundControl.Common.Mapping.Parameters;

//    public class EventsArchiveConverter : Converter
//    {
//        #region Fields
//
//        private readonly Converter mDefaultConverter = new DefaultConverter();
//
//        #endregion
//
//        #region Properties
//
//        [XmlElement("Pair")]
//        public List<MutableKeyValuePair<sbyte, MutableKeyValuePair<string, Converter>>> KeyValuePairs { get; set; }
//
//        #endregion
//
//        #region IValueConverter
//
//        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            var integer = (Integer8)value;
//            var pair = KeyValuePairs.FirstOrDefault(x => x.Key == integer.TypedValue);
//
//            if (pair != null)
//                return pair.Value;
//
//            var eventDescr = integer.TypedValue + ": Unknown";
//            return new MutableKeyValuePair<string, Converter>(eventDescr, mDefaultConverter);
//        }
//
//        #endregion
//    }
}
