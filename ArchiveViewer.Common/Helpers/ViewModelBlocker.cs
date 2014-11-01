namespace ArchiveViewer.Common.Helpers
{
    using Extensions;

    public sealed class ViewModelBlocker : Blockable
    {
        #region Fields

        private readonly ViewModelBase mViewModel;

        #endregion

        #region Constructor

        public ViewModelBlocker(ViewModelBase viewModel)
        {
            viewModel.CheckNull("viewModel");

            mViewModel = viewModel;

            Block();
        }

        #endregion

        #region Blockable

        protected override void Block()
        {
            mViewModel.Enabled = false;
        }

        protected override void Unblock()
        {
            mViewModel.Enabled = true;
        }

        #endregion
    }
}
