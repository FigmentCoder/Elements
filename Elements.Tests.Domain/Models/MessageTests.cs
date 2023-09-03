// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable EqualExpressionComparison

using System;

using Xunit;
using FsCheck.Xunit;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using static Elements.Domain.Models.MessageConstructor;

namespace Elements.Tests.Domain.Models
{
    public class MessageTests
    {
        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ConstructorDoesNotThrow(string value)
            => Record.Exception(() => Message(value))
                .Pipe(Assert.Null);

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ConstructorThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => Message(value));

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorMessageFromString(string value)
        {
            Message message = value;

            Assert.Equal(value, message.Value);
        }

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ImplicitOperatorMessageFromNullEmptyStringThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => { Message message = value; });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorStringFromMessage(string value)
        {
            var message = Message(value);

            string stringFromMessage = message;

            Assert.Equal(message.Value, stringFromMessage);
        }

        [Fact]
        public void ImplicitOperatorStringFromNullMessageThrows()
            => Assert.Throws<ArgumentNullException>(
                () =>
                {
                    Message message = null;
                    string stringFromMessage = message;
                });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ToStringSucceeds(string value)
            => Assert.Equal(
                Message(value).Value,
                Message(value).ToString());

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void EqualsIsTrue(string value)
            => Assert.True(
                Message(value).Equals(Message(value)));
    }
}