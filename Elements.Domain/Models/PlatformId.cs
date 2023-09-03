using System.Collections.Generic;

using Elements.Common.Types;
using Elements.Common.Extensions;

namespace Elements.Domain.Models
{
    public class PlatformId : ValueObject<string>
    {
        private PlatformId(string value)
            : base(value) { }

        internal static PlatformId New(string value)
            => value.IsNull()
                ? Empty()
                : new PlatformId(value);

        public static PlatformId Empty()
            => new(string.Empty);

        private PlatformId() { }

        public static implicit operator PlatformId(string value)
            => New(value);

        public static implicit operator string(PlatformId platformId)
            => platformId.IsNull()
                ? string.Empty
                : platformId.Value;

        protected override IEnumerable<object> 
            GetEqualityComponents()
        {
            yield return Value;
        }
    }

    public static class PlatformIdConstructor
    {
        public static PlatformId PlatformId(string value)
            => Models.PlatformId.New(value);
    }
}