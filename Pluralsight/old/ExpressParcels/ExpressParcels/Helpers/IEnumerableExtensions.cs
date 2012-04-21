using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExpressParcels.Helpers
{
    public static class IEnumerableExtensions
    {
         public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
         {
             var coll = new ObservableCollection<T>();
             foreach (var item in list)
                 coll.Add(item);
             return coll;
         }

        public static void AddToObservableCollection<T>(this IEnumerable<T> list, ObservableCollection<T> coll)
        {
            foreach (var item in list)
                coll.Add(item);
        }
    }
}