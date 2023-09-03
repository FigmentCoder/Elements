using System;

namespace Elements.Common.Constructors
{
	public static class GuidConstructor
	{
		public static Guid Guid()
			=> System.Guid.NewGuid();
	}
}