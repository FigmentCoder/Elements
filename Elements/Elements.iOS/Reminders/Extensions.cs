using System;
using System.Threading.Tasks;

using Foundation;
using EventKit;
using Xamarin.Essentials;

using Elements.Common.Extensions;
using Elements.Common.Types;

using static Xamarin.Essentials.Permissions;
using static Elements.Common.Types.ResultConstructors;

namespace Elements.iOS.Reminders
{
    internal static class DateTimeExtensions
    {
        public static NSDate ToNSDate(this DateTime date)
            => date.Kind.Equals(DateTimeKind.Unspecified)
                ? (NSDate)DateTime.SpecifyKind(date, DateTimeKind.Local)
                : (NSDate)date;
    }

    internal static class EKEventStoreExtensions
    {
        public static EKReminder GetReminder(
            this EKEventStore ekEventStore,
            string platformId)
            => (EKReminder)ekEventStore.GetCalendarItem(platformId);
    }

    internal static class PermissionStatusExtensions
    {
        public static async Task<Result> RequestAsync()
            => await RequestAsync<Permissions.Reminders>()
                .PipeAsync(result => 
                    result.IsGranted() 
                        ? Granted 
                        : Denied.ConcatS(Message));

        private static bool IsGranted(this PermissionStatus permissionStatus)
            => permissionStatus == PermissionStatus.Granted;

        private const string Message = 
            "Open settings to grant Reminder permission to App";
    }
}