// ReSharper disable ConvertToAutoProperty

using System;
using Elements.Common.Types;
using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Domain.Models
{
    public class Reminder : Entity
    {
        internal Reminder(
            Guid id,
            Title title,
            DateTime dateTime,
            Recurrence recurrence,
            Season season,
            PlatformId platformId,
            bool isEnabled)
        {
            Id = id;
            Title = title;
            DateTime = dateTime;
            Recurrence = recurrence;
            Season = season;
            PlatformId = platformId;
            IsEnabled = isEnabled;
        }

        private Reminder() { }

        private Title _title;
        public Title Title
        {
            get => 
                _title;
            private set =>
                _title = value
                ?? throw NullException(nameof(Title));
        }

        private DateTime _dateTime;
        public DateTime DateTime
        {
            get 
            {
                var now =
                    DateTime.Now;

                var schedule =
                    new DateTime(
                        now.Year,
                        _dateTime.Month,
                        _dateTime.Day,
                        _dateTime.Hour,
                        _dateTime.Minute,
                        _dateTime.Second);

                var future =
                    new DateTime(
                        now.AddYears(1).Year,
                        _dateTime.Month,
                        _dateTime.Day,
                        _dateTime.Hour,
                        _dateTime.Minute,
                        _dateTime.Second);

                return schedule > now ? schedule : future;
            }
            private set =>
                _dateTime = value;
        }

        private Recurrence _recurrence;
        public Recurrence Recurrence
        {
            get => 
                _recurrence;
            private set => 
                _recurrence = value;
        }

        private Season _season;
        public Season Season
        {
            get => 
                _season;
            private set => 
                _season = value;
        }

        private PlatformId _platformId;
        public PlatformId PlatformId
        {
            get => 
                _platformId;
            private set => 
                _platformId = value
                ?? throw NullException(nameof(PlatformId));
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => 
                _isEnabled;
            private set => 
                _isEnabled = value;
        }

        public Reminder With(
            Title title)
            => new(
                Id,
                title,
                DateTime,
                Recurrence,
                Season,
                PlatformId,
                IsEnabled);
    }

    public enum Recurrence
    {
        Monthly,
        Yearly
    }

    public enum Season
    {
        Spring,
        Summer,
        Fall,
        Winter
    }

    public static class ReminderConstructor
    {
        public static Reminder Reminder(
            Guid id,
            Title title,
            DateTime dateTime,
            Recurrence recurrence,
            Season season,
            PlatformId platformId,
            bool isEnabled) 
            => new(
                id,
                title,
                dateTime,
                recurrence,
                season,
                platformId,
                isEnabled);
    }
}