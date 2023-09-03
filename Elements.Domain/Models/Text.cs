using Elements.Common.Extensions;
using Elements.Common.Types;

using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Domain.Models
{
    public class Text : StringValueObject
    {
        internal Text(string value)
            : base(value) { }

        private Text() { }

        public static implicit operator Text(string value)
            => new(value);

        public static implicit operator string(Text text)
            => text.IsNull()
                ? throw NullException(nameof(text))
                : text.Value;
    }

    public static class TextConstructor
    {
        public static Text Text(string value)
            => new(value);
    }
}