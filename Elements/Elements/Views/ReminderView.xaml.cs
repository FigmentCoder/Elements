using Xamarin.Forms;
using static Elements.ViewModels.ReminderViewModelFactory;

namespace Elements.Views
{
    public partial class ReminderView : ContentPage
    {
        public ReminderView()
        {
            InitializeComponent();

            BindingContext =
                ReminderViewModel();
        }
    }
}