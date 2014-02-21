namespace GroundControl.Archives.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using GroundControl.Common;
    using GroundControl.Common.Extensions;
    using GroundControl.Common.Models.Archives;

    internal sealed class ArchivesViewModel : ViewModelBase
    {
        #region Fields

        private readonly ArchivesPlugin mPlugin;

        #endregion

        #region Constructor

        public ArchivesViewModel(ArchivesPlugin plugin)
        {
            plugin.CheckNull("plugin");

            mPlugin = plugin;
            DisplayName = "Архіви";
            Archives = new List<ArchiveViewModel>();
        }

        #endregion

        #region Properties

        public List<ArchiveViewModel> Archives { get; private set; }

        #endregion

        #region Methods

        private void OnArchiveViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Enabled")
                return;

            var viewModel = (ArchiveViewModel)sender;
            Archives.ForEach(x => x.Enabled = viewModel.Enabled);
        }

        public void AddArchives(IEnumerable<ArchiveType> archiveTypes)
        {
            archiveTypes.CheckNull("archiveTypes");

            foreach (var type in archiveTypes)
            {
                var manager = new ArchiveManager(type, mPlugin.SerialPortService, mPlugin.ModbusMaster);
                var viewModel = new ArchiveViewModel(type, manager);
                viewModel.PropertyChanged += OnArchiveViewModelPropertyChanged;
                Archives.Add(viewModel);
            }

            OnPropertyChanged("Archives");
        }

        #endregion
    }
}
