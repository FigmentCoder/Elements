// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable EqualExpressionComparison

using System;

using Xunit;
using FsCheck.Xunit;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using static Elements.Domain.Models.HeaderConstructor;

namespace Elements.Tests.Domain.Models
{
    public class HeaderTests
    {
        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ConstructorDoesNotThrow(string value)
            => Record.Exception(() => Header(value))
                .Pipe(Assert.Null);

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ConstructorThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => Header(value));

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorHeaderFromString(string value)
        {
            Header header = value;

            Assert.Equal(value, header.Value);
        }

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ImplicitOperatorHeaderFromNullEmptyStringThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => { Header header = value; });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorStringFromHeader(string value)
        {
            var header = Header(value);

            string stringFromHeader = header;

            Assert.Equal(header.Value, stringFromHeader);
        }

        [Fact]
        public void ImplicitOperatorStringFromNullHeaderThrows()
        => Assert.Throws<ArgumentNullException>(
            () =>
            {
                Header header = null;
                string stringFromHeader = header;
            });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ToStringSucceeds(string value)
            => Assert.Equal(
                Header(value).Value,
                Header(value).ToString());

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void EqualsIsTrue(string value)
            => Assert.True(
                Header(value).Equals(Header(value)));
    }
}