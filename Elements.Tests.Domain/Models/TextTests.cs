// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable EqualExpressionComparison

using System;

using Xunit;
using FsCheck.Xunit;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using static Elements.Domain.Models.TextConstructor;

namespace Elements.Tests.Domain.Models
{
    public class TextTests
    {
        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ConstructorDoesNotThrow(string value)
            => Record.Exception(() => Text(value))
                .Pipe(Assert.Null);

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ConstructorThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => Text(value));

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorTextFromString(string value)
        {
            Text text = value;

            Assert.Equal(value, text.Value);
        }

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ImplicitOperatorTextFromNullEmptyStringThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => { Text text = value; });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorStringFromText(string value)
        {
            var text = Text(value);

            string stringFromText = text;

            Assert.Equal(text.Value, stringFromText);
        }

        [Fact]
        public void ImplicitOperatorStringFromNullTextThrows()
        => Assert.Throws<ArgumentNullException>(
            () =>
            {
                Text text = null;
                string stringFromText = text;
            });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ToStringSucceeds(string value)
            => Assert.Equal(
                Text(value).Value,
                Text(value).ToString());

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void EqualsIsTrue(string value)
            => Assert.True(
                Text(value).Equals(Text(value)));
    }
}