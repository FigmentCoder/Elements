using System;

using Foundation;
using EventKit;

using Elements.Common.Extensions;
using Elements.Models;

using static Elements.iOS.Reminders.NSCalendarConstructor;
using static Elements.iOS.Reminders.EKRecurrenceRuleConstructor;

namespace Elements.iOS.Reminders
{
    internal static class EkReminderConstructor
    {
        public static EKReminder EkReminder(
            EKEventStore ekEventStore,
            ReminderDto reminderDto) 
            => EKReminder
                .Create(ekEventStore)
                .Pipe(reminder =>
                {
                    reminder.Title = reminderDto.Title;
                    reminder.Notes = reminder.Notes;
                    reminder.Calendar = ekEventStore.DefaultCalendarForNewReminders;
                    reminder.DueDateComponents = reminderDto.DateTime.ToNSDateComponents();
                    reminder.RecurrenceRules = new []{ reminderDto.Recurrence.ToRecurrenceRule() };
                    return reminder;
                });

        private static NSDateComponents ToNSDateComponents(
            this DateTime dateTime)
            => NSCalendar()
                .Pipe(calendar => 
                    calendar.Components(
                        NSCalendarUnit.Day | 
                        NSCalendarUnit.Month | 
                        NSCalendarUnit.Year |
                        NSCalendarUnit.Hour |
                        NSCalendarUnit.Minute,
                        dateTime.ToNSDate()));

        private static EKRecurrenceRule ToRecurrenceRule(
            this RecurrenceDto recurrenceDto)
            => recurrenceDto switch
            {
                RecurrenceDto.Monthly => 
                    EKRecurrenceRule(
                        EKRecurrenceFrequency.Monthly, 1),
                RecurrenceDto.Yearly => 
                    EKRecurrenceRule(
                        EKRecurrenceFrequency.Yearly, 1),
                _ => EKRecurrenceRule(
                    EKRecurrenceFrequency.Yearly, 1)
            };
    }

    public static class NSCalendarConstructor
    {
        public static NSCalendar NSCalendar() 
            => new(NSCalendarType.Gregorian);
    }

    public static class EKEventStoreConstructor
    {
        public static EKEventStore EKEventStore()
            => new();
    }

    public static class EKRecurrenceRuleConstructor
    {
        public static EKRecurrenceRule EKRecurrenceRule(
            EKRecurrenceFrequency frequency,
            nint interval)
            => new(frequency, interval, null);
    }
}