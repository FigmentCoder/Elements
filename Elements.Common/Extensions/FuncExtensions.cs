using System;

namespace Elements.Common.Extensions
{
    public static class FuncExtensions
    {
        public static Func<A, bool> Not<A>(this Func<A, bool> predicate)
            => a => !predicate(a);

        public static Func<A, bool> And<A>(this Func<A, bool> left, Func<A, bool> right)
            => a => left(a) && right(a);

        public static Func<A, bool> Or<A>(this Func<A, bool> left, Func<A, bool> right)
            => a => left(a) || right(a);
    }
}