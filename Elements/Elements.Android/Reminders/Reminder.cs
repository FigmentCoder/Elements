using System.Threading.Tasks;

using Xamarin.Forms;

using Elements.Common.Extensions;
using Elements.Common.Types;
using Elements.Models;
using Elements.Services;

using static Xamarin.Essentials.Permissions;
using static Elements.Droid.Reminders.PermissionStatusExtensions;
using static Elements.Droid.Reminders.ReminderRepository;

[assembly: Dependency(typeof(Elements.Droid.Reminders.Reminder))]
namespace Elements.Droid.Reminders
{
    internal class Reminder :
        IRequestAccess,
        IAddReminder,
        IRemoveReminder
    {
        public async Task<Result> Request()
            => await CheckStatusAsync<CalendarWrite>()
                .PipeAsync(RequestAsync);

        public Task<ReminderDto> Add(
            ReminderDto reminderDto)
            => Task.Run(() => 
                reminderDto.ToContentValues()
                    .Pipe(AddReminder)
                    .Pipe(reminderDto.With));

        public Task<ReminderDto> Remove(
            ReminderDto reminderDto)
            => Task.Run(() => 
                RemoveReminder(reminderDto.PlatformId)
                    .Pipe(reminderDto.With));
    }
}