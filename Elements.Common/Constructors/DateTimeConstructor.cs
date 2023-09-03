using System;

namespace Elements.Common.Constructors
{
    public static  class DateTimeConstructor
    {
        public static DateTime DateTime(
            int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
            => new (year, month, day, hour, minute, second, kind);
    }
}