using Elements.Common.Types;
using Elements.Common.Extensions;

using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Domain.Models
{
    public class Header : StringValueObject
    {
        internal Header(string value)
            : base(value) { }

        private Header() { }

        public static implicit operator Header(string value)
            => new(value);

        public static implicit operator string(Header header)
            => header.IsNull()
                ? throw NullException(nameof(header))
                : header.Value;
    }

    public static class HeaderConstructor
    {
        public static Header Header(string value)
            => new(value);
    }
}