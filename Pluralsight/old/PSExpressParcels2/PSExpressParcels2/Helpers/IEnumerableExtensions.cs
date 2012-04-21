using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PSExpressParcels2.Helpers
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Convert IEnumerable into a Observable Collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
         public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
         {
             var collection = new ObservableCollection<T>();
             foreach (var item in list)
             {
                 collection.Add(item);
             }
             return collection;
         }

        /// <summary>
        /// Add contents of an IEnumerable to an ObservableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="collection"></param>
        public static void AddToObservableCollection<T>(this IEnumerable<T> list,
            ObservableCollection<T> collection)
        {
            foreach(var item in list)
                collection.Add(item);
        }
    }
}