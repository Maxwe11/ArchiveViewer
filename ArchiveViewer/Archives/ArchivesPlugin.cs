namespace ArchiveViewer.Archives
{
    using System;
    using System.IO;
    using Common;
    using Common.Extensions;
    using Common.Mapping.Converters;
    using Common.Models.Archives;
    using Common.Services;
    using Services;
    using ViewModels;
    using Views;

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

            mModbusMaster = bundle.GetService<IModbusMasterService>();

            mSerialPortService = bundle.GetService<ISerialPortService>();

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
