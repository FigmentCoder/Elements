using Xamarin.Forms;
using static Elements.ViewModels.MainViewModelFactory;

namespace Elements.Views
{	
	public partial class MainView : ContentPage
	{	
		public MainView ()
		{
			InitializeComponent ();

            BindingContext =
                MainViewModel();
        }
	}

	public static class MainViewConstructor
	{
		public static MainView MainView()
			=> new();
	}
}