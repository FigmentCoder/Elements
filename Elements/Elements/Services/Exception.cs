using System;
using System.Threading.Tasks;

using Microsoft.AppCenter.Crashes;

namespace Elements.Services
{
    internal static class ExceptionHandler
    {
        public static async Task Track(Exception exception)
            => await Task.Run(() => Crashes.TrackError(exception));

        public static async Task Display(Exception exception)
            => await Alert.Display(exception.Message);
    }
}