namespace GroundControl.Common.Mapping.Converters
{
    using System.Collections.ObjectModel;

    public class StringConverterPairsCollection<TKey> : KeyedCollection<TKey, StringConverterPair>
    {
        protected override TKey GetKeyForItem(StringConverterPair item)
        {
            var obj = (StringConverterPair<TKey>)item;
            return obj.Id;
        }
    }
}
