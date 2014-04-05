namespace GroundControl.Archives
{
    using System;
    using System.IO;

    using GroundControl.Archives.Services;
    using GroundControl.Archives.ViewModels;
    using GroundControl.Archives.Views;
    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Converters;
    using GroundControl.Common.Models.Archives;
    using GroundControl.Common.Services;
    using GroundControl.Common;

    public sealed class ArchivesPlugin : PluginBase
    {
        #region Fields

        private readonly ISerialPortService mSerialPortService;

        private readonly IModbusMasterService mModbusMaster;

        private readonly Lazy<ArchivesViewModel> mViewModel;

        private readonly Lazy<ArchivesView> mView;

        #endregion

        #region Constructor

        public ArchivesPlugin(IBundle bundle)
            : base("Archives", bundle)
        {
            bundle.CheckNull("bundle");

            var service = bundle.GetService(typeof(IModbusMasterService));
            mModbusMaster = (IModbusMasterService)service;

            service = bundle.GetService(typeof(ISerialPortService));
            mSerialPortService = (ISerialPortService)service;

            var path = Path.Combine(bundle.ConfigurationPath, "archives");
            var archivesProvider = new ArchivesProviderService(path);
            
            bundle.RegisterService(typeof(IDataProviderService<ArchiveType>), archivesProvider);

            ConvertersCollection.Instance(Path.Combine(bundle.ConfigurationPath, "converters.xml"));
            var archives = archivesProvider.GetCollection();

            mViewModel = new Lazy<ArchivesViewModel>(() =>
            {
                var viewModel = new ArchivesViewModel(this);
                return viewModel;
            });

            mView = new Lazy<ArchivesView>(() =>
            {
                var viewModel = mViewModel.Value;
                var view = new ArchivesView(viewModel);
                viewModel.AddArchives(archives);
                return view;
            });

            //TO DO: check LoadArchives error
            //TO DO: check ServiceNotFoundException
        }

        #endregion

        #region PluginBase

        public override IView GetView()
        {
            return mView.Value;
        }

        public override ViewModelBase GetViewModel()
        {
            return mViewModel.Value;
        }

        #endregion

        #region Properties

        public ISerialPortService SerialPortService { get { return mSerialPortService; } }

        public IModbusMasterService ModbusMaster { get { return mModbusMaster; } }

        #endregion
    }
}
