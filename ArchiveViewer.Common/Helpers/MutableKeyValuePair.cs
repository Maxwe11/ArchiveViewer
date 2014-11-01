namespace ArchiveViewer.Common.Helpers
{
    using Properties;

    public class MutableKeyValuePair<TKey, TValue>
    {
        #region Constructors

        [UsedImplicitly]
        public MutableKeyValuePair()
        {
        }

        public MutableKeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        #endregion

        #region Properties

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        #endregion
    }
}
