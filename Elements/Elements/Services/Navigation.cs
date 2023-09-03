// ReSharper disable ParameterTypeCanBeEnumerable.Local

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using Elements.ViewModels;

using static System.Activator;
using static Elements.Common.Constructors.DictionaryConstructor;
using static Elements.Common.Constructors.ListConstructor;
using static Elements.Services.ViewNames;

namespace Elements.Services
{
    internal static class Navigation
    {
        private static readonly Dictionary<string, IList<string>> Dictionary =
            Dictionary(IList((MainPageView, IList(ArticleView, ScheduleView, ReminderView))));

        public static async Task Navigate(string source, string destination, object @object = null)
        {
            if (Dictionary.TryGetValue(source, out var destinations))
            {
                if (destinations.Contains(destination))
                {
                    var navigationPage = (NavigationPage)Application.Current.MainPage;
                    var destinationPageType = Type.GetType(destination);
                    var destinationPage = (Page)CreateInstance(destinationPageType!);
                    (destinationPage.BindingContext as ViewModel)?.Initialize(@object!);
                    await navigationPage.Navigation.PushAsync(destinationPage);
                }
            }
        }

        public static async Task NavigateBack()
        {
            var navigationPage = (NavigationPage)Application.Current.MainPage;
            await navigationPage.Navigation.PopAsync();
        }
    }

    internal static class ViewNames
    {
        public const string MainPageView = NameSpace + "MainPage";
        public const string ArticleView = NameSpace + "ArticleView";
        public const string ScheduleView = NameSpace + "ScheduleView";
        public const string ReminderView = NameSpace + "ReminderView";
        public const string NameSpace = "Elements.Views.";
    }
}