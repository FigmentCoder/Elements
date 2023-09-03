using Elements.Models;

namespace Elements.ViewModels
{
	internal class ArticleViewModel : ViewModel
    {
        private ArticleDto _article;
        public ArticleDto Article
        {
            get => _article;
            set
            {
                _article = value;
                OnPropertyChanged(nameof(Article));
            }
        }

        public override void Initialize(object @object)
            => Article = @object as ArticleDto;
    }

    internal static class ArticleViewModelConstructor
    {
        public static ArticleViewModel ArticleViewModel()
            => new();
    }
}