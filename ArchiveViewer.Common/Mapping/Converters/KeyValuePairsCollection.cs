namespace ArchiveViewer.Common.Mapping.Converters
{
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;
    using Helpers;

    [CollectionDataContract(ItemName = "KeyValuePair")]
    public class KeyValuePairsCollection<TKey, TValue> : KeyedCollection<TKey, Pair<TKey, TValue>>
    {
        protected override TKey GetKeyForItem(Pair<TKey, TValue> item)
        {
            return item.First;
        }

        public void Add(TKey key, TValue value)
        {
            Add(Pair.Create(key, value));
        }
    }
}
