using System;

namespace Elements.Common.Extensions;

public static class EnumExtensions
{
    public static bool IsDefined(this Enum @enum)
        => Enum.IsDefined(@enum.GetType(), @enum);

    public static bool IsNotDefined(this Enum @enum)
        => @enum.IsDefined();
}