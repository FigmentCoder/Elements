// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable EqualExpressionComparison

using Xunit;
using FsCheck.Xunit;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using static System.String;
using static Elements.Domain.Models.PlatformIdConstructor;

namespace Elements.Tests.Domain.Models
{
    public class PlatformIdTests
    {
        [Fact]
        public void ConstructorNullEqualsEmpty()
            => Assert.Equal(
                Elements.Domain.Models.PlatformId.Empty(), PlatformId(null));

        [Fact]
        public void PlatformIdEmptyConstructorEqualsEmptyValue()
        {
            var value =
                Elements.Domain.Models
                    .PlatformId.Empty()
                    .Value;

            Assert.Equal(Empty, value);
        }

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorPlatformIdFromString(string value)
        {
            PlatformId platformId = value;

            Assert.Equal(value, platformId.Value);
        }

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorStringFromPlatformId(string value)
        {
            var platformId = PlatformId(value);

            string stringFromPlatformId = platformId;

            Assert.Equal(platformId.Value, stringFromPlatformId);
        }

        [Fact]
        public void ImplicitOperatorStringFromNullPlatformIdIsEmpty()
        {
            PlatformId platformId = null;

            string stringFromPlatformId = platformId;

            Assert.Equal(
                Elements.Domain.Models
                    .PlatformId.Empty(),
                stringFromPlatformId);
        }

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ToStringSucceeds(string value)
            => Assert.Equal(
                PlatformId(value).Value,
                PlatformId(value).ToString());

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void EqualsIsTrue(string value)
            => Assert.True(
                PlatformId(value).Equals(PlatformId(value)));
    }
}