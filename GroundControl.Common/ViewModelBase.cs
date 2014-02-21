namespace GroundControl.Common
{
    using System.ComponentModel;

    using GroundControl.Common.Properties;

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Fields

        private string mDisplayName;

        private bool mEnabled = true;

        #endregion

        #region Properties

        public virtual string DisplayName
        {
            get { return mDisplayName; }
            protected set
            {
                if (value == mDisplayName)
                    return;

                mDisplayName = value;
                OnPropertyChanged("DisplayName");
            }
        }

        public virtual bool Enabled
        {
            get { return mEnabled; }
            set
            {
                if (value == mEnabled)
                    return;

                mEnabled = value;
                OnPropertyChanged("Enabled");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
