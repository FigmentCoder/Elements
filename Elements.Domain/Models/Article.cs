using System;
using System.Linq;
using System.Collections.Generic;

using Elements.Common.Types;

using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Domain.Models
{
    public class Article : Entity
    {
        internal Article(
            Guid id,
            Title title,
            ImageName imageName,
            IList<Section> sections)
        {
            Id = id;
            Title = title;
            ImageName = imageName;
            Sections = sections;
        }

        private Article() { }

        private Title _title;
        public Title Title
        {
            get => 
                _title;
            private set =>
                _title = value
                ?? throw NullException(nameof(Title));
        }

        private ImageName _imageName;
        public ImageName ImageName
        {
            get => 
                _imageName;
            private set =>
                _imageName = value
                ?? throw NullException(nameof(ImageName));
        }

        private IList<Section> _sections;
        public IList<Section> Sections 
        {
            get => 
                _sections
                .OrderBy(s => s.Order)
                .ToList();
            private set => 
                _sections = value 
                ?? throw NullException(nameof(Sections));
        }

        public Article With(
            Section section)
            => new(
                Id,
                Title, 
                ImageName,
                Sections
                .Where(s => !s.Equals(section))
                .Append(section)
                .ToList());
    }

    public static class ArticleConstructor
	{
		public static Article Article(
			Guid id,
			Title title,
            ImageName imageName,
			IList<Section> sections) 
            => new(id, title, imageName, sections);
	}
}