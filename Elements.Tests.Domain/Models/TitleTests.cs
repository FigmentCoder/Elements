// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable EqualExpressionComparison

using System;

using Xunit;
using FsCheck.Xunit;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using static Elements.Domain.Models.TitleConstructor;

namespace Elements.Tests.Domain.Models
{
    public class TitleTests
    {
        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ConstructorDoesNotThrow(string value)
            => Record.Exception(() => Title(value))
                .Pipe(Assert.Null);

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ConstructorThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => Title(value));

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorTitleFromString(string value)
        {
            Title title = value;

            Assert.Equal(value, title.Value);
        }

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ImplicitOperatorTitleFromNullEmptyStringThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => { Title title = value; });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorStringFromTitle(string value)
        {
            var title = Title(value);

            string stringFromTitle = title;

            Assert.Equal(title.Value, stringFromTitle);
        }

        [Fact]
        public void ImplicitOperatorStringFromNullTitleThrows()
            => Assert.Throws<ArgumentNullException>(
                () =>
                {
                    Title title = null;
                    string stringFromTitle = title;
                });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ToStringSucceeds(string value)
            => Assert.Equal(
                Title(value).Value,
                Title(value).ToString());

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void EqualsIsTrue(string value)
            => Assert.True(
                Title(value).Equals(Title(value)));
    }
}