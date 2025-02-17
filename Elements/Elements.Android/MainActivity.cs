﻿using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

using Acr.UserDialogs;

namespace Elements.Droid
{
    [Activity(
        Label = "Elements",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        ConfigurationChanges = 
            ConfigChanges.ScreenSize | 
            ConfigChanges.Orientation |
            ConfigChanges.UiMode |
            ConfigChanges.ScreenLayout |
            ConfigChanges.SmallestScreenSize,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this);
            UserDialogs.Init(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(
            int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}