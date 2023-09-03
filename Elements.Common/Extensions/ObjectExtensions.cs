using System;

namespace Elements.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object @object)
            => @object == null;

        public static bool IsNotNull(this object @object)
            => @object != null;

        public static void IsNotNull(this object @object, Action action)
        {
            if (@object.IsNotNull()) action();
        }
    }
}