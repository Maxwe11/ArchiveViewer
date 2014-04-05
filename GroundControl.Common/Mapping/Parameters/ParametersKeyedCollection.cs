namespace GroundControl.Common.Mapping.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;

    [CollectionDataContract(IsReference = true)]
    public class ParametersKeyedCollection : KeyedCollection<byte?, ParametersCollection>
    {
        #region Fields

        private static readonly string ExceptionMessage = "CollectionId is null. ParametersKeyedCollection should " +
                                                          "contain only one element without id or more than one " +
                                                          "but all elements should have id";

        #endregion

        #region KeyedCollection

        protected override byte? GetKeyForItem(ParametersCollection item)
        {
            return item.CollectionId;
        }

        #endregion

        public new void Add(ParametersCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            if (Count == 0)
            {
                base.Add(collection);
                return;
            }

            if (Count == 1)
            {
                if (((IList<ParametersCollection>)this)[0].CollectionId == null)
                    throw new InvalidOperationException("ParametersKeyedCollection already contains element without id");

                if (collection.CollectionId == null)
                    throw new ArgumentException(ExceptionMessage, "collection");

                base.Add(collection);
                return;
            }

            if (collection.CollectionId == null)
                throw new InvalidOperationException("ParametersKeyedCollection already contains elements so element should have id");

            base.Add(collection);
        }
    }
}
