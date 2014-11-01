namespace ArchiveViewer
{
    using System;
    using System.ComponentModel;
    using System.IO.Ports;
    using System.Windows.Forms;
    using Archives;
    using Common;
    using Common.Extensions;
    using Common.Services;
    using FastMember;
    using Modbus.Device;
    using Properties;
    using Services;
    using ViewModels;
    using Views;

    internal class App : IDisposable
    {
        #region Main

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var app = new App(Application.StartupPath))
            {
                Application.Run(app.View);
            }
        }

        #endregion

        #region Fields

        private readonly Settings mSettings = new Settings();

        private readonly SerialPort mSerialPort = new SerialPort();

        private readonly IBundle mBundle;

        private readonly Lazy<ObjectAccessor> mPortAccessor;

        private readonly AppView mView;

        private bool mSettingsChanged;

        #endregion

        #region Constructor

        private App(string startupPath)
        {
            startupPath.CheckNull("startupPath");

            mSettings.PropertyChanged += OnSettingsPropertyChanged;
            mSerialPort.SetUpPortFromSettings(mSettings);

            mBundle = new AppBundle(startupPath, mSettings);
            mPortAccessor = new Lazy<ObjectAccessor>(() => ObjectAccessor.Create(mSerialPort));
            CreateServices();
            
            var viewModel = new AppViewModel(mSettings.AppViewModel_DisplaName, mBundle);
            mView = new AppView(viewModel);

            var plugins = new PluginBase[] { new ArchivesPlugin(mBundle) };

            viewModel.AddPlugins(plugins);
        }

        #endregion

        #region Properties

        private Form View { get { return mView; } }

        #endregion

        #region IDisponsable

        void IDisposable.Dispose()
        {
            try
            {
                mSerialPort.Dispose();
                if (mSettingsChanged)
                    mSettings.Save();
            }
            catch
            {
            }
        }

        #endregion

        #region Methods

        private void CreateServices()
        {
            var serialPortService = new SerialPortService(mSerialPort);

            var modbusMaster = ModbusSerialMaster.CreateRtu(mSerialPort);
            var masterService = new ModbusMasterService(modbusMaster);

            mBundle.RegisterService(typeof(IModbusMasterService), masterService);
            mBundle.RegisterService(typeof(ISerialPortService), serialPortService);
        }

        private void OnSettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var property = e.PropertyName;
            mPortAccessor.Value[property] = mSettings[property];
            mSettingsChanged = true;
        }

        #endregion
    }
}
