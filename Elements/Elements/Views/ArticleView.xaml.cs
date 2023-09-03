using Xamarin.Forms;
using static Elements.ViewModels.ArticleViewModelConstructor;

namespace Elements.Views
{	
	public partial class ArticleView : ContentPage
	{	
		public ArticleView ()
		{
			InitializeComponent ();

            BindingContext =
                ArticleViewModel();
        }
	}
}