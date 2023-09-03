using Android.App;
using Android.Content;

using Elements.Common.Extensions;

using static System.String;
using static Android.Provider.CalendarContract.Events;

namespace Elements.Droid.Reminders
{
    internal static class ReminderRepository
    {
        private static readonly ContentResolver Resolver =
            Application.Context.ContentResolver;

        public static string AddReminder(ContentValues contentValues)
            => Resolver
                .Insert(ContentUri!, contentValues)?
                .LastPathSegment;

        public static string RemoveReminder(string id)
            => Resolver
                .Delete(ContentUri.With(id))
                .Pipe(_ => Empty);
    }
}