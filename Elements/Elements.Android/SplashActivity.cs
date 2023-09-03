using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Elements.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
        NoHistory = true,
        Icon = "@mipmap/icon",
        MainLauncher = true,
        ConfigurationChanges =
            ConfigChanges.ScreenSize |
            ConfigChanges.Orientation |
            ConfigChanges.UiMode |
            ConfigChanges.ScreenLayout |
            ConfigChanges.SmallestScreenSize,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartActivity
                (new Intent(this, typeof(MainActivity)));
            Finish();
        }
    }
}