using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elements.Common.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// ForEach index++
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this List<T> source, Action<T, int> action)
        {
            var i = 0;
            foreach (var item in source)
            {
                action(item, i);
                i++;
            }
        }

        /// <summary>
        /// ForEach ++index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this List<T> source, Action<int, T> action)
        {
            var i = 0;
            foreach (var item in source)
            {
                ++i;
                action(i, item);
            }
        }

        public static void ForEach<T>(this IList<T> values, Action<T> action)
        {
            foreach (var value in values)
            {
                action(value);
            }
        }

        public static async Task ForEachAsync<T>(this IList<T> list, Func<T, Task> func)
        {
            foreach (var value in list)
            {
                await func(value);
            }
        }

        /// <summary>
        /// Returns a List with a single Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<T> ToSList<T>(this T item)
            => new() { item };

        public static bool IsNullOrEmpty<T>(this IList<T> iList)
            => iList == null || !iList.Any();

        public static bool IsNotNullOrEmpty<T>(this IList<T> iList)
            => !IsNullOrEmpty(iList);
    }
}