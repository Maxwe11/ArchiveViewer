namespace GroundControl.Common.Mapping.Converters
{
    using System.Runtime.Serialization;

    [DataContract]
    [KnownType(typeof(StringConverterPair<byte>))]
    [KnownType(typeof(StringConverterPair<ushort>))]
    [KnownType(typeof(StringConverterPair<uint>))]
//    [KnownType(typeof(StringConverterPair<ulong>))]
    [KnownType(typeof(StringConverterPair<sbyte>))]
    [KnownType(typeof(StringConverterPair<short>))]
    [KnownType(typeof(StringConverterPair<int>))]
//    [KnownType(typeof(StringConverterPair<long>))]

    public class StringConverterPair
    {
        #region Constructor

        protected internal StringConverterPair(string text, string converterName)
        {
            Text = text;
            ConverterName = converterName;
        }

        #endregion

        #region Properties

        [DataMember(IsRequired = true, Order = 1)]
        public string Text { get; private set; }

        [DataMember(IsRequired = true, Order = 2)]
        public string ConverterName { get; private set; }

        #endregion
    }

    [DataContract]
    public class StringConverterPair<T> : StringConverterPair
    {
        #region Constructor

        public StringConverterPair(T id, string text, string converterName)
            : base(text, converterName)
        {
            Id = id;
        }

        #endregion

        #region Properties

        [DataMember(IsRequired = true, Order = 0)]
        public T Id { get; private set; }

        #endregion
    }
}
