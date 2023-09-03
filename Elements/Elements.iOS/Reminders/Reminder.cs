using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Essentials;

using Elements.Common.Extensions;
using Elements.Common.Types;
using Elements.Models;
using Elements.Services;

using static System.String;

using static Xamarin.Essentials.Permissions;

using static Elements.Common.Constructors.ExceptionConstructors;
using static Elements.iOS.Reminders.EkReminderConstructor;
using static Elements.iOS.Reminders.EKEventStoreConstructor;
using static Elements.iOS.Reminders.PermissionStatusExtensions;

[assembly: Dependency(typeof(Elements.iOS.Reminders.Reminder))]
namespace Elements.iOS.Reminders
{
    internal class Reminder :
        IRequestAccess, 
        IAddReminder, 
        IRemoveReminder
    {
        public async Task<Result> Request()
            => await CheckStatusAsync<Permissions.Reminders>()
                .PipeAsync(RequestAsync);

        public Task<ReminderDto> Add(ReminderDto reminderDto)
            => Task.Run(() =>
                EKEventStore()
                    .Pipe(ekEventStore => 
                        EkReminder(ekEventStore, reminderDto)
                    .Pipe(reminder =>
                    {
                        ekEventStore.SaveReminder(reminder, true, out var failure);
                        return failure.IsNull()
                            ? reminderDto.With(reminder.CalendarItemIdentifier)
                            : throw Exception(failure.Description);
                    })));

        public Task<ReminderDto> Remove(ReminderDto reminderDto)
            => Task.Run(() =>
                EKEventStore()
                    .Pipe(ekEventStore =>
                    {
                        var reminder = 
                            ekEventStore
                            .GetReminder(reminderDto.PlatformId);
                        return reminder.IsNotNull()
                            .IfElse(() =>
                            {
                                ekEventStore
                                    .RemoveReminder(reminder, true, out var failure);
                                return failure.IsNull()
                                    ? reminderDto.With(Empty)
                                    : throw Exception(failure.Description);
                            },() => reminderDto.With(Empty));
                    }));
    }
}