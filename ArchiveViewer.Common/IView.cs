namespace ArchiveViewer.Common
{
    using System.Windows.Forms;

    public interface IView
    {
        Control Control { get; }
    }
}