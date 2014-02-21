namespace GroundControl.Common
{
    public abstract class PluginBase
    {
        #region Constructor

        protected PluginBase(string name, IBundle bundle)
        {
            Name = name;
            Bundle = bundle;
        }

        #endregion

        #region Properties
        
        public string Name { get; private set; }

        protected IBundle Bundle { get; private set; }

        #endregion

        #region Methods

        public abstract IView GetView();

        public abstract ViewModelBase GetViewModel();

        #endregion
    }
}
