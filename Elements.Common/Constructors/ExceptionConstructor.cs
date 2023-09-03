using System;

namespace Elements.Common.Constructors
{
	public static class ExceptionConstructors
	{
		public static ArgumentNullException NullException(string message)
			=> new(message);

		public static ArgumentOutOfRangeException OutOfRangeException(string message)
			=> new(message);

        public static Exception Exception(string message)
            => new(message);
    }
}