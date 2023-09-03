using System;
using Xamarin.Forms;

namespace Elements.Services
{
    internal static class NavigationPageConstructor
    {
        public static NavigationPage NavigationPage(
            Page page)
            => new(page);
    }

    internal static class CommandConstructors
    {
        public static Command Command(
            Action action)
            => new(action);

        public static Command<T> Command<T>(
            Action<T> action)
            => new(action);
    }
}