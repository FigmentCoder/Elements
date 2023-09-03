using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;

using Elements.Common.Extensions;

using static Elements.Views.BusyViewConstructor;

namespace Elements.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusyView : PopupPage
    {
        public BusyView()
        {
            InitializeComponent();
        }
    }

    public static class BusyViewConstructor
    {
        public static BusyView BusyView()
        => new();
    }

    internal static class BusyViewExtensions
    {
        public static async Task DisplayBusyView()
            => await
                PopupNavigation
                .Instance
                .PushAsync(BusyView());

        public static async Task DismissBusyView()
        {
            var popupNavigation =
                PopupNavigation.Instance;
            await popupNavigation
                .PopupStack.Any()
                .IfTrue(() => popupNavigation.PopAsync());
        }
    }
}