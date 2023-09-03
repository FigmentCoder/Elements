using System;
using System.Collections.Generic;

namespace Elements.Models
{
    public class ArticleDto : Dto
    {
        internal ArticleDto(
            Guid id,
            string title,
            string imageName,
            IList<SectionDto> sections)
        {
            Id = id;
            Title = title;
            ImageName = imageName;
            Sections = sections;
        }

        public string Title { get; }
        public string ImageName { get;  }
        public IList<SectionDto> Sections { get; }
    }

    public static class ArticleDtoConstructor
    {
        public static ArticleDto ArticleDto(
            Guid id,
            string title,
            string imageName,
            IList<SectionDto> sections)
            => new(id, title, imageName, sections);
    }
}