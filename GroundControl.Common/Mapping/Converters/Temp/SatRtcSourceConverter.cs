namespace GroundControl.Common.Mapping.Converters
{
    using System;
    using System.Globalization;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;

//    public class SatRtcSourceConverter : Converter
//    {
//        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            value.CheckNull("value");
//
//            var integer = (Integer32)value;
//
//            switch (integer.TypedValue)
//            {
//                case 1:
//                    return "бит 0 - машина состяний RTC в случае сбоя";
//                case 2:
//                    return "бит 1 - GPS модуль";
//                case 4:
//                    return "бит 2 - modbus (радиолиния)";
//                default:
//                    return integer.TypedValue + " Uknown";
//            }
//        }
//    }
}
