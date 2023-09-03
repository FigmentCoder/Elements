using System;

namespace Elements.Models
{
	public class SectionDto : Dto
	{
		internal SectionDto(
            Guid id,
            string header,
            string text,
            int order)
        {
            Id = id;
            Header = header;
            Text = text;
            Order = order;
        }

        public string Header { get; }
		public string Text { get;  }
        public int Order { get; }
    }

	public static class SectionDtoConstructor
    {
        public static SectionDto SectionDto(
            Guid id,
            string header,
            string text,
            int order)
            => new(id, header, text, order);
    }
}