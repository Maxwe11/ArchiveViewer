namespace GroundControl.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using GroundControl.Common;
    using GroundControl.Common.Extensions;
    using GroundControl.Common.Properties;

    internal sealed class AppViewModel : ViewModelBase
    {
        #region Fields

        private readonly IBundle mBundle;

        #endregion

        #region Constructor

        internal AppViewModel(string displayName, IBundle appBundle)
        {
            displayName.CheckNull("displayName");
            appBundle.CheckNull("appBundle");

            DisplayName = displayName;            
            mBundle = appBundle;
            Plugins = new List<PluginBase>();
            ShowSerialPortSettingDialog = new RelayCommand(x => MessageBox.Show(x.ToString()));
        }

        #endregion

        #region Properties

        #region Data

        [UsedImplicitly]
        public IEnumerable<PluginBase> Plugins { get; private set; }

        #endregion

        #region Commands

        public ICommand ShowSerialPortSettingDialog { get; private set; }

        #endregion

        #endregion

        #region Methods

        public void AddPlugins(IEnumerable<PluginBase> plugins)
        {
            plugins.CheckNull("plugins");

            var list = (List<PluginBase>)Plugins;
            list.AddRange(plugins);
            OnPropertyChanged("Plugins");
        }

        #endregion
    }
}
