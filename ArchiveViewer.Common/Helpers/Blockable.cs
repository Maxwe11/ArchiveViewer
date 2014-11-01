namespace ArchiveViewer.Common.Helpers
{
    using System;

    public abstract class Blockable : IDisposable
    {
        #region IDisposable

        public void Dispose()
        {
            Unblock();
        }

        #endregion

        #region Methods

        protected abstract void Block();

        protected abstract void Unblock();

        #endregion
    }
}
