using System;
using System.Collections.Generic;

namespace Elements.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            IEnumerable<ValueTuple<TKey, TValue>> keyValuePairs)
        {
            foreach (var keyValuePair in keyValuePairs)
                source.Add(keyValuePair.Item1, keyValuePair.Item2);

            return source;
        }

        public static void AddTo<TKey, TValue>(
            this IEnumerable<ValueTuple<TKey, TValue>> source,
            Dictionary<TKey, TValue> target)
                => target.AddRange(source);
    }
}