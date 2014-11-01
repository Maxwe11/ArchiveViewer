namespace ArchiveViewer.Common.Mapping.Converters
{
    using System;
    using System.Runtime.Serialization;
    using Extensions;

    [DataContract]
    [KnownType(typeof(DefaultConverter))]
    [KnownType(typeof(MatchCrc16Converter))]
    [KnownType(typeof(ToUnixTimeConverter))]
    [KnownType(typeof(BitsToStringConverter))]
    [KnownType(typeof(ToStringConverter<byte>))]
    [KnownType(typeof(ToStringConverter<ushort>))]
    [KnownType(typeof(ToStringConverter<uint>))]
    [KnownType(typeof(ToStringConverter<sbyte>))]
    [KnownType(typeof(ToStringConverter<short>))]
    [KnownType(typeof(ToStringConverter<int>))]
    [KnownType(typeof(ToStringConverterPairConverter<byte>))]
    [KnownType(typeof(ToStringConverterPairConverter<ushort>))]
    [KnownType(typeof(ToStringConverterPairConverter<uint>))]
    [KnownType(typeof(ToStringConverterPairConverter<sbyte>))]
    [KnownType(typeof(ToStringConverterPairConverter<short>))]
    [KnownType(typeof(ToStringConverterPairConverter<int>))]
    public abstract class Converter : IValueConverter
    {
        #region Constructors

        protected Converter(string name)
        {
            name.CheckNull("name");

            Name = name;
        }

        #endregion

        #region Properties

        [DataMember(IsRequired = true, Order = 0)]
        public string Name { get; private set; }

        #endregion

        #region IValueConverter

        public abstract object Convert(object value, object parameter);

        public virtual object ConvertBack(object value, object parameter)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
