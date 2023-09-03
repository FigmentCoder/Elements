using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace Elements.Common.Extensions
{
    public static class SystemExtensions
    {
        public static IEnumerable<PropertyInfo> GetProperties<T>(this T type)
            => type.GetType().GetProperties();

        public static IEnumerable<PropertyInfo> GetProperties<T>()
            => typeof(T).GetProperties();

        public static int ToInt(this Enum enumValue)
            => (int)(object)enumValue;

        public static string Name(this Assembly assembly)
            => assembly.GetName().Name;

        public static Stream GetStream(this Assembly assembly, string value)
            => assembly.GetManifestResourceStream(value);
    }
}