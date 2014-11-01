namespace ArchiveViewer.Common
{
    public interface ICommand
    {
        void Execute(params object[] args);
    }
}
