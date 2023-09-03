
using System;

namespace Elements.Common.Extensions
{
    public static class StringExtensions
    {
        public static string Concat(this string left, string right)
            => left + right;

        public static string ConcatS(this string left, string right)
            => left + " " + right;

        public static bool IsNullOrEmpty(this string value)
            => string.IsNullOrEmpty(value);

        public static long ToLong(this string value)
            => long.Parse(value);
    }

    public static class StringFuncExtensions
    {
        public static Func<string,bool> IsNullOrEmpty
            => s => s.IsNullOrEmpty();

        public static Func<string,bool> IsNotNullOrEmpty
            => s => !s.IsNullOrEmpty();
    }
}