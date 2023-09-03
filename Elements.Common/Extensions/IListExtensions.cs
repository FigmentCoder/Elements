using System;
using System.Collections.Generic;

namespace Elements.Common.Extensions
{
    public static class IListExtensions
    {
        public static int GetIndex<T>(
            this IList<T> list,
            Predicate<T> predicate)
            => ((List<T>)list).FindIndex(predicate);
    }
}