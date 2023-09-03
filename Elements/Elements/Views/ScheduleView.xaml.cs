using Xamarin.Forms;
using static Elements.ViewModels.ScheduleViewModelConstructor;

namespace Elements.Views
{	
	public partial class ScheduleView : ContentPage
	{	
		public ScheduleView ()
		{
			InitializeComponent ();
			BindingContext = ScheduleViewModel();
        }
    }
}