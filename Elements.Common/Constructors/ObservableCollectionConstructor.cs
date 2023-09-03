using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Elements.Common.Constructors
{
    public static class ObservableCollectionConstructor
    {
        public static ObservableCollection<T> ObservableCollection<T>(List<T> list) 
            => new(list);

        public static ObservableCollection<T> ObservableCollection<T>(IList<T> list)
            => new(list);
    }
}