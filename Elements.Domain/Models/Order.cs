using Elements.Common.Extensions;
using Elements.Common.Types;

namespace Elements.Domain.Models
{
    public class Order : IntValueObject
    {
        private Order(int value)
            : base(value) { }

        internal static Order New(int value)
            => value < 0
                ? Zero()
                : new Order(value);

        public static Order Zero()
            => new(0);

        private Order() { }

        public static implicit operator Order(int value)
            => New(value);

        public static implicit operator int(Order order)
            => order.IsNull()
                ? 0
                : order.Value;
    }

    public static class OrderConstructor
    {
        public static Order Order(int value)
            => Models.Order.New(value);
    }
}