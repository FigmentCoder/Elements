using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Elements.Models
{
    public class ReminderDto : Dto, INotifyPropertyChanged
    {
        public ReminderDto(
            Guid id,
            string title,
            DateTime dateTime,
            RecurrenceDto recurrence,
            SeasonDto season,
            string platformId,
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

        public string Title { get; }
        public DateTime DateTime { get; }
        public RecurrenceDto Recurrence { get; }
        public SeasonDto Season { get; }

        private string _platformId;
        public string PlatformId
        {
            get => _platformId;
            set
            {
                _platformId = value;
                OnPropertyChanged(nameof(PlatformId));
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum RecurrenceDto
    {
        Monthly,
        Yearly
    }

    public enum SeasonDto
    {
        Spring,
        Summer,
        Fall,
        Winter
    }

    public static class ReminderDtoConstructor
    {
        public static ReminderDto ReminderDto(
            Guid id,
            string title,
            DateTime dateTime,
            RecurrenceDto recurrence,
            SeasonDto season,
            string platformId,
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

    public static class ReminderDtoExtensions
    {
        public static ReminderDto With(
            this ReminderDto reminderDto,
            string platformId)
        {
            reminderDto.PlatformId = platformId;
            return reminderDto;
        }
    }
}