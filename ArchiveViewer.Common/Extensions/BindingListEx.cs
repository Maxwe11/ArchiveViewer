namespace ArchiveViewer.Common.Extensions
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public static class BindingListEx
    {
        public static void AddRange<T>(this BindingList<T> list, IEnumerable<T> items)
        {
            var raiseListChanged = list.RaiseListChangedEvents;
            
            if (raiseListChanged)
                list.RaiseListChangedEvents = false;

            foreach (var item in items)
                list.Add(item);

            if (raiseListChanged)
                list.RaiseListChangedEvents = true;

            list.ResetBindings();
        }
    }
}
