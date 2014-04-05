namespace GroundControl.Common.Mapping.Converters
{
    using System;
    using System.Xml;    
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;

    [CollectionDataContract(IsReference = true)]
    public class ConvertersCollection : KeyedCollection<string, Converter>
    {
        #region Static

        private static ConvertersCollection instance;

        public static ConvertersCollection Instance(string path = null)
        {
            if (instance == null && string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path", "Instance is not initialized. Call with non null path first");

            if (instance == null)
            {
                var s = new DataContractSerializer(typeof(ConvertersCollection));
                using (var reader = XmlReader.Create(path))
                    instance = (ConvertersCollection)s.ReadObject(reader);

                instance.Add(new DefaultConverter());
                instance.Add(new MatchCrc16Converter());
                instance.Add(new ToUnixTimeConverter());
            }

            return instance;
        }

        #endregion

        #region Constructor

        #endregion

        #region KeyedCollection

        protected override string GetKeyForItem(Converter item)
        {
            return item.Name;
        }

        #endregion
    }
}
