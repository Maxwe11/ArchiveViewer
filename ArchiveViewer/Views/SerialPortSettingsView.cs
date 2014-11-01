namespace ArchiveViewer.Views
{
    using System;
    using System.Windows.Forms;
    using Common.Extensions;
    using Models;
    using ViewModels;

    internal partial class SerialPortSettingsView : UserControl
    {
        private readonly SerialPortSettingsViewModel mViewModel;

        public SerialPortSettingsView(SerialPortSettingsViewModel viewModel)
        {
            viewModel.CheckNull("viewModel");
            mViewModel = viewModel;
            
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            mPortNameCmbBx.DataSource = SerialPortInfo.GetSerialPortsInfo();
            mPortNameCmbBx.DisplayMember = "FriendlyName";
            mPortNameCmbBx.ValueMember = "Name";
        }
    }
}
