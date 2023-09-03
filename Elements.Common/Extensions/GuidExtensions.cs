using System;

namespace Elements.Common.Extensions
{
	public static class GuidExtensions
	{
		public static bool IsEmpty(this Guid guid)
			=> guid.Equals(Guid.Empty);

		public static bool IsNotEmpty(this Guid guid)
			=> !IsEmpty(guid);
    }
}