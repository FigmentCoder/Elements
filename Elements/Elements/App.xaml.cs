using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;

using static Elements.Common.Services.UserSecrets;
using static Elements.Persistence.DatabaseSetupRunner;
using static Elements.Services.NavigationPageConstructor;
using static Elements.Views.MainViewConstructor;

namespace Elements
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage =
                NavigationPage(MainView());
            DatabaseSetup();
        }

        protected override void OnStart()
        {
            var secrets =
                Secrets(GetType(),"Elements");
            AppCenter.Start(
                secrets["ios"] +
                secrets["android"],
                typeof(Crashes));
        }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}