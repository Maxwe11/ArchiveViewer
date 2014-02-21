namespace GroundControl.Common.Services
{
    using System.Collections.ObjectModel;

    public interface IDataProviderService<TData>
    {
        Collection<TData> GetCollection();
    }
}
