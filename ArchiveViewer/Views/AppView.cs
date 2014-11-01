namespace ArchiveViewer.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Common;
    using Common.Extensions;
    using Telerik.WinControls.UI.Docking;
    using ViewModels;

    internal partial class AppView : Form
    {
        #region Fields

        private readonly AppViewModel mViewModel;

        private readonly Dictionary<string, Action> mPropertyChangedActions = new Dictionary<string, Action>();

        private readonly Dictionary<object, ICommand> mCommands = new Dictionary<object, ICommand>();

        #endregion

        #region Constructor

        internal AppView(AppViewModel viewModel)
        {
            viewModel.CheckNull("viewModel");
            mViewModel = viewModel;

            InitializeComponent();
            BindViewModel();
        }

        private void BindViewModel()
        {
            Text = mViewModel.DisplayName;
            SetUpViewModelPropertyChangedHandlers();
            mViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void SetUpViewModelPropertyChangedHandlers()
        {
            var pluginsPropertyName = mViewModel.MemberName(x => x.Plugins);
            var enabledPropertyName = mViewModel.MemberName(x => x.Enabled);
            
            Action subscribeAddAction = AddPluginsViews;
            Action unsubscribeAddAction = () => mPropertyChangedActions.Remove(pluginsPropertyName);
            Action subscribeEnabledAction = () => mPropertyChangedActions.Add(enabledPropertyName, ViewModelEnabledChanged);

            var action = (Action)Delegate.Combine(subscribeAddAction, unsubscribeAddAction, subscribeEnabledAction);
            mPropertyChangedActions.Add(pluginsPropertyName, action);
        }

        #endregion

        #region Methods

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Action action;
            if (mPropertyChangedActions.TryGetValue(e.PropertyName, out action))
                action();
        }

        private void AddPluginsViews()
        {
            foreach (var plugin in mViewModel.Plugins)
            {
                var viewModel = plugin.GetViewModel();
                var view = plugin.GetView();

                var host = new HostWindow(view.Control)
                {
                    Text = viewModel.DisplayName,
                    DocumentButtons = DocumentStripButtons.ActiveWindowList
                };

                mRadDock.AddDocument(host);
            }
        }

        private void ViewModelEnabledChanged()
        {
        }

        #endregion
    }
}
