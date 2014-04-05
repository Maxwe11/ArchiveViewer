namespace GroundControl.Archives.Services
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Helpers;
    using GroundControl.Common.Models.Archives;
    using GroundControl.Common.Services;

    internal class ArchivesProviderService : IDataProviderService<ArchiveType>
    {
        #region Fields

        //private readonly ILoggingService mLogger;

        private readonly Lazy<Collection<ArchiveType>> mLazy;

        #endregion

        #region Constructor

        //internal ArchivesProviderService(ILoggingService logger, string path)
        internal ArchivesProviderService(string path)
        {
//            logger.CheckNull("logger");
            path.CheckNull("path");

//            mLogger = logger;
            mLazy = new Lazy<Collection<ArchiveType>>(() => Load(path));
        }

        #endregion

        #region IDataProviderService

        public Collection<ArchiveType> GetCollection()
        {
            return mLazy.Value;
        }

        #endregion

        #region Methods

        private Collection<ArchiveType> Load(string path)
        {
            if (!Directory.Exists(path))
                throw new ApplicationException("Archives config directory doesn't exists");

            var configs = Directory.GetFiles(path, "*.xml");
            var archives = EntityCollection.Create((ArchiveType x) => x.Id);
            var serializer = new DataContractSerializer(typeof(ArchiveType));

            foreach (var config in configs)
            {
                try
                {
                    using (var reader = XmlReader.Create(config))
                    {
                        var archiveType = (ArchiveType)serializer.ReadObject(reader);
                        archives.Add(archiveType);
                    }
                }
                catch //(Exception ex)
                {
                    //mLogger.LogToUser(Strings.FailedToLoadArchive + config);
                }
            }

            return archives;
        }

        #endregion
    }
}
