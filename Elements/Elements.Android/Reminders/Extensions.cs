using System;
using System.Threading.Tasks;

using Android.Content;
using Xamarin.Essentials;

using Elements.Common.Extensions;
using Elements.Common.Types;
using Elements.Models;

using Uri = Android.Net.Uri;

using static Android.Provider.CalendarContract.Events.InterfaceConsts;
using static Xamarin.Essentials.Permissions;

using static Elements.Common.Constructors.DateTimeConstructor;
using static Elements.Common.Types.ResultConstructors;

namespace Elements.Droid.Reminders
{
    internal static class ReminderDtoExtensions
    {
        public static ContentValues ToContentValues(
            this ReminderDto reminderDto)
            => new ContentValues()
                .Pipe(values =>
            {
                values.Put(Title, reminderDto.Title);
                values.Put(Dtstart, reminderDto.DateTime.ToAndroidDateTime());
                values.Put(Dtend, reminderDto.DateTime.ToAndroidDateTime());
                values.Put(Rrule, reminderDto.Recurrence.ToRecurrenceRule());
                values.Put(EventTimezone, TimeZone);
                values.Put(CalendarId, 3);
                values.Put(EventEndTimezone, TimeZone);
                return values;
            });

        private static long ToAndroidDateTime(
            this DateTime dateTime)
            => (long)dateTime.ToUniversalTime()
                .Subtract(DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                .TotalMilliseconds;

        private static string ToRecurrenceRule(
            this RecurrenceDto recurrenceDto)
            => recurrenceDto switch
            {
                RecurrenceDto.Monthly => "FREQ=MONTHLY",
                RecurrenceDto.Yearly => "FREQ=YEARLY",
                _ => "FREQ=YEARLY"
            };

        private static readonly string TimeZone = 
            TimeZoneInfo.Local.DisplayName;
    }

    internal static class PermissionStatusExtensions
    {
        public static async Task<Result> RequestAsync()
            => await RequestAsync<CalendarWrite>()
                .PipeAsync(result =>
                    result.IsGranted()
                        ? Granted
                        : Denied.ConcatS(Message));
        
        private static bool IsGranted(this PermissionStatus permissionStatus)
            => permissionStatus == PermissionStatus.Granted;

        private const string Message =
            "Open settings to grant Calendar permission to App";
    }

    internal static class UriExtensions
    {
        public static Uri With(this Uri uri, string id)
            => ContentUris.WithAppendedId(uri, id.ToLong());
    }

    internal static class ContResolverExtensions
    {
        public static int Delete(this ContentResolver contentResolver, Uri uri)
            => contentResolver.Delete(uri, null, null);
    }
}