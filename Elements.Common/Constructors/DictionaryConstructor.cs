using System;
using System.Collections.Generic;

using Elements.Common.Extensions;

namespace Elements.Common.Constructors
{
    public static class DictionaryConstructor
    {
        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(
            IEnumerable<ValueTuple<TKey, TValue>> keyValuePairs)
                => new Dictionary<TKey, TValue>()
            .Pipe(dictionary => dictionary.AddRange(keyValuePairs));
    }
}