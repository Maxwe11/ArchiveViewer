namespace GroundControl.Common.Mapping.Converters
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    class ToStringConverterPairConverter<T> : Converter
    {
        private static readonly StringConverterPair DefaultPair = new StringConverterPair("Uknown", "DefaultConverter");

        public ToStringConverterPairConverter(string name)
            : base(name)
        {
            Collection = new StringConverterPairsCollection<T>();
        }


        [DataMember(IsRequired = true, Order = 1)]
        public StringConverterPairsCollection<T> Collection { get; private set; }

        public override object Convert(object value, object parameter)
        {
            T key = (T)value;

            try
            {
                var pair = Collection[key: key];
                return pair;
            }
            catch (Exception)
            {
            }

            return DefaultPair;
        }
    }
}
