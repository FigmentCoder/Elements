using System;
using Elements.Common.Types;
using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Domain.Models
{
	public class Section : Entity
	{
        internal Section(
            Guid id,
            Header header,
            Text text,
            Order order)
        {
            Id = id;
            Header = header;
            Text = text;
            Order = order;
        }

        private Section() { }

        private Header _header;
        public Header Header
        {
            get => 
                _header;
            private set =>
                _header = value
                ?? throw NullException(nameof(Header));
        }

        private Text _text;
        public Text Text
        {
            get => 
                _text;
            private set => 
                _text = value
                ?? throw NullException(nameof(Text));
        }

        private Order _order;
        public Order Order
        {
            get => 
                _order;
            private set =>
                _order = value 
                ?? throw NullException(nameof(Order));
        }

        public Section With(
            Text text)
            => new(Id, Header, text, Order);
    }

	public static class SectionConstructor
	{
		public static Section Section(
			Guid id,
			Header header,
			Text text,
            Order order)
            => new(id, header, text, order);
	}
}