using Elements.Common.Types;
using Elements.Common.Extensions;

using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Domain.Models
{
    public class Title : StringValueObject
    {
        internal Title(string value)
            : base(value) { }

        private Title() { }

        public static implicit operator Title(string value)
            => new(value);

        public static implicit operator string(Title title)
            => title.IsNull()
                ? throw NullException(nameof(title))
                : title.Value;
    }

    public static class TitleConstructor
    {
        public static Title Title(string value)
            => new(value);
    }
}