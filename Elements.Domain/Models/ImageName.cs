using Elements.Common.Types;
using Elements.Common.Extensions;

using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Domain.Models
{
    public class ImageName : StringValueObject
    {
        internal ImageName(string value)
            : base(value) { }
        private ImageName() { }

        public static implicit operator ImageName(string value)
            => new(value);

        public static implicit operator string(ImageName imageName)
            => imageName.IsNull()
                ? throw NullException(nameof(imageName))
                : imageName.Value;
    }

    public static class ImageNameConstructor
    {
        public static ImageName ImageName(string value)
            => new(value);
    }
}