using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Elements.Common.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// ForEach index++
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
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
        public static void ForEach<T>(this IEnumerable<T> source, Action<int, T> action)
        {
            var i = 0;
            foreach (var item in source)
            {
                ++i;
                action(i, item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEach(this IEnumerable source, Action<object> action)
        {
            foreach (var value in source)
            {
                action(value);
            }
        }

        public static IEnumerable<T> Select<T>(this IEnumerable source, Func<object, T> selector)
            => Enumerable.Select(source.Cast<object>(), selector);

        public static IList<T> ToIList<T>(this IEnumerable<T> source)
            => source.ToList();

        public static IEnumerable<T> WhereAnd<T>(this IEnumerable<T> source, Func<T, bool> predicate1, Func<T, bool> predicate2)
            => source.Where(t => predicate1(t) && predicate2(t));

        public static IEnumerable<T> WhereOr<T>(this IEnumerable<T> source, Func<T, bool> predicate1, Func<T, bool> predicate2)
            => source.Where(t => predicate1(t) || predicate2(t));

        public static bool AnyAnd<T>(this IEnumerable<T> source, Func<T, bool> predicate1, Func<T, bool> predicate2)
            => source.Any(t => predicate1(t) && predicate2(t));

        public static bool AnyOr<T>(this IEnumerable<T> source, Func<T, bool> predicate1, Func<T, bool> predicate2)
            => source.Any(t => predicate1(t) || predicate2(t));

        public static bool AllAnd<T>(this IEnumerable<T> source, Func<T, bool> predicate1, Func<T, bool> predicate2)
            => source.All(t => predicate1(t) && predicate2(t));

        public static bool AllOr<T>(this IEnumerable<T> source, Func<T, bool> predicate1, Func<T, bool> predicate2)
            => source.All(t => predicate1(t) || predicate2(t));

        public static bool IsEnumerable(this Type type)
            => type.GetInterfaces().Contains(typeof(IEnumerable));

        public static bool All(this IEnumerable source, Func<object, bool> predicate)
            => Enumerable.All(source.Cast<object>(), predicate);

        public static bool CountEquals<T1, T2>(this IEnumerable<T1> left, IEnumerable<T2> right)
            => left.Count() == right.Count();

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static bool HasValuesCountEquals<T1, T2>(this IEnumerable<T1> left, IEnumerable<T2> right)
            => left.Any() && left.Count() == right.Count();

        public static bool HasValuesEquals<T>(this IEnumerable<T> left, IEnumerable<T> right, IEqualityComparer<T> comparer)
        {
            var leftP = left.ToList();
            var rightP = right.ToList();

            if (!leftP.Any())
                return false;

            var leftAll = leftP.All(t => rightP.Contains(t, comparer));
            var rightAll = rightP.All(t => leftP.Contains(t, comparer));

            return leftAll && rightAll;
        }
    }
}