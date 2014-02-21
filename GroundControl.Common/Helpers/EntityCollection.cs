namespace GroundControl.Common.Helpers
{
    using System;
    using System.Collections.ObjectModel;

    using GroundControl.Common.Extensions;

    public class EntityCollection<TKey, TData> : KeyedCollection<TKey, TData>
    {
        #region Fields

        private readonly Func<TData, TKey> mKeyGen;

        #endregion

        public EntityCollection(Func<TData, TKey> keyGen)
        {
            keyGen.CheckNull("keyGen");

            mKeyGen = keyGen;
        }

        protected override TKey GetKeyForItem(TData item)
        {
            return mKeyGen(item);
        }
    }

    public static class EntityCollection
    {
        public static EntityCollection<TKey, TData> Create<TKey, TData>(Func<TData, TKey> keyGen)
        {
            return new EntityCollection<TKey, TData>(keyGen);
        }
    }
}
