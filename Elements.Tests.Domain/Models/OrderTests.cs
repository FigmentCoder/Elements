// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable EqualExpressionComparison

using Xunit;
using FsCheck.Xunit;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using static Elements.Domain.Models.OrderConstructor;

namespace Elements.Tests.Domain.Models
{
    public class OrderTests
    {
        [Property(Arbitrary = new[] { typeof(NegativeIntGenerator) })]
        public void ConstructorNegativeIntEqualsZero(int value)
        => Assert.Equal(
            Elements.Domain.Models.Order.Zero(), Order(value));

        [Fact]
        public void OrderZeroConstructorEqualsZeroValue()
        {
            var value =
                Elements.Domain.Models
                    .Order.Zero()
                    .Value;

            Assert.Equal(0, value);
        }

        [Property(Arbitrary = new[] { typeof(IntGenerator) })]
        public void ImplicitOperatorOrderFromInt(int value)
        {
            Order order = value;

            Assert.Equal(value, order.Value);
        }

        [Property(Arbitrary = new[] { typeof(IntGenerator) })]
        public void ImplicitOperatorIntFromOrder(int value)
        {
            var order = Order(value);

            int intFromOrder = order;

            Assert.Equal(order.Value, intFromOrder);
        }

        [Fact]
        public void ImplicitOperatorIntFromNullOrderIsZero()
        {
            Order order = null;

            int intFromOrder = order;

            Assert.Equal(
                Elements.Domain.Models
                    .Order.Zero()
                    .Value,
                intFromOrder);
        }

        [Property(Arbitrary = new[] { typeof(IntGenerator) })]
        public void ToStringSucceeds(int value)
            => Assert.Equal(
                Order(value).Value.ToString(),
                Order(value).ToString());

        [Property(Arbitrary = new[] { typeof(IntGenerator) })]
        public void EqualsIsTrue(int value)
            => Assert.True(
                Order(value).Equals(Order(value)));
    }
}