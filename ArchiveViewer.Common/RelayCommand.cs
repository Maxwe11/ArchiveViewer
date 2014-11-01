namespace ArchiveViewer.Common
{
    using System;
    using Extensions;

    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object[]> mAction;

        #endregion

        #region Constructors

        public RelayCommand(Action<object[]> action)
        {
            action.CheckNull("action");

            mAction = action;
        }

        #endregion

        #region ICommand

        public void Execute(params object[] args)
        {
            mAction(args);
        }

        #endregion
    }
}
