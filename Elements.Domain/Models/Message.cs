using Elements.Common.Extensions;
using Elements.Common.Types;

using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Domain.Models
{
    public class Message : StringValueObject
    {
        internal Message(string value)
            : base(value) { }

        private Message() { }

        public static implicit operator Message(string value)
            => new(value);

        public static implicit operator string(Message message)
            => message.IsNull()
                ? throw NullException(nameof(message))
                : message.Value;
    }

    public static class MessageConstructor
    {
        public static Message Message(string value)
            => new(value);
    }
}