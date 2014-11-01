namespace ArchiveViewer.Archives.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Common;
    using Telerik.WinControls.UI.Docking;
    using ViewModels;

    internal partial class ArchivesView : UserControl, IView
    {
        #region Fields

        private readonly IEnumerable<ArchiveViewModel> mArchiveViewModels;

        #endregion

        #region Constructor

        public ArchivesView(ArchivesViewModel viewModel)
        {
            InitializeComponent();

            mArchiveViewModels = viewModel.Archives;
            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        #endregion

        #region Properties

        public Control Control
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region Methods

        private void OnLoad(object sender, EventArgs e)
        {
            var service = mRadDock.GetService<DragDropService>();
            service.ShowDockingGuides = false;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Archives")
                return;

            foreach (var viewModel in mArchiveViewModels)
            {
                var view = new ArchiveView(viewModel);
                var host = new HostWindow(view)
                {
                    Text = viewModel.DisplayName,
                    DocumentButtons = DocumentStripButtons.ActiveWindowList
                };

                mRadDock.AddDocument(host);
            }
        }

        #endregion
    }
}
