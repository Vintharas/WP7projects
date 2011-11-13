using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TwitterClientPrototype.Helpers
{
    public static class ObservableCollectionExtensions
    {
         public static void Add<T>(this ObservableCollection<T> collection, IEnumerable<T> list)
         {
             foreach (var item in list)
             {
                 collection.Add(item);
             }
         }
    }
}