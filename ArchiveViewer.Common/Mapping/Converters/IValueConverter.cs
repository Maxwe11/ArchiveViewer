namespace ArchiveViewer.Common.Mapping.Converters
{
    internal interface IValueConverter
    {
        object Convert(object value, object parameter);

        object ConvertBack(object value, object parameter);
    }
}
