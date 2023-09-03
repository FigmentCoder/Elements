using System.Collections.Generic;

namespace Elements.Common.Constructors
{
    public static class ListConstructor
    {
        public static List<T> List<T>(T t, params T[] ts)
        {
            return new List<T>(Yield());
            IEnumerable<T> Yield()
            {
                yield return t;
                T[] array = ts;
                for (int i = 0; i < array.Length; i++)
                {
                    yield return array[i];
                }
            }
        }

        public static IList<T> IList<T>(T t, params T[] ts) 
            => List(t, ts);
    }
}