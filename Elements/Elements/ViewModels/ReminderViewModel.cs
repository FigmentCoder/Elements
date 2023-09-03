using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using Elements.Common.Extensions;
using Elements.Common.Services;
using Elements.Common.Types;
using Elements.Models;
using Elements.Services;

using static Elements.Common.Services.AsyncCommandConstructors;
using static Elements.Services.Repository;
using static Elements.Services.ExceptionHandler;
using static Elements.Services.Navigation;
using static Elements.Views.BusyViewExtensions;

namespace Elements.ViewModels
{
    internal class ReminderViewModel : ViewModel
    {
        private readonly Func<Task<IList<ReminderDto>>> GetReminders;
        private readonly Func<ReminderDto,Task> SaveReminder;
        private readonly Func<Task<Result>> RequestAccess;
        private readonly Func<ReminderDto,Task<ReminderDto>> AddReminder;
        private readonly Func<ReminderDto,Task<ReminderDto>> RemoveReminder;
        private readonly Func<Result,Task> DisplayAlert;
        private readonly Func<Task> NavigatePrevious;
        private readonly Func<Task> DisplayBusyView;
        private readonly Func<Task> DismissBusyView;

        internal ReminderViewModel(
            Func<Task<IList<ReminderDto>>> getReminders,
            Func<ReminderDto,Task> saveReminder,
            Action<Exception> trackException,
            Action<Exception> displayException,
            Func<Task<Result>> requestAccess,
            Func<ReminderDto, Task<ReminderDto>> addReminder,
            Func<ReminderDto, Task<ReminderDto>> removeReminder,
            Func<Result,Task> displayAlert,
            Func<Task> navigatePrevious,
            Func<Task> displayBusyView,
            Func<Task> dismissBusyView)
        {
            GetReminders = getReminders;
            SaveReminder = saveReminder;
            RequestAccess = requestAccess;
            AddReminder = addReminder;
            RemoveReminder = removeReminder;
            DisplayAlert = displayAlert;
            NavigatePrevious = navigatePrevious;
            DisplayBusyView = displayBusyView;
            DismissBusyView = dismissBusyView;

            LoadingSelected =
                AsyncCommand(
                    OnLoadingSelected,
                    trackException);

            ToggleReminderSelected =
                AsyncCommand<ReminderDto>(
                    OnToggleReminderSelected,
                    displayException);
        }

        private IList<ReminderDto> _reminders;
        public IList<ReminderDto> Reminders
        {
            get => _reminders;
            set
            {
                _reminders = value;
                OnPropertyChanged(nameof(Reminders));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public IAsyncCommand LoadingSelected { get; }
        private async Task OnLoadingSelected()
            => await
                OnRequestAccessSelected()
                    .PipeAsync(
                OnLoadRemindersSelected);

        private async Task OnRequestAccessSelected()
            => await 
                RequestAccess()
                .PipeAsync(result => result
                    .IsNotGranted()
                    .IfTrue(async() =>
                    {
                        await DisplayAlert(result);
                        await NavigatePrevious();
                    }));

        private async Task OnLoadRemindersSelected()
        {
            IsLoading = true;
            Reminders = await GetReminders();
            IsLoading = false;
        }

        public IAsyncCommand<ReminderDto> ToggleReminderSelected { get; }
        private async Task OnToggleReminderSelected(
            ReminderDto reminderDto)
            => await
                RequestAccess()
                .PipeAsync(result => result
                    .IsGranted()
                    .IfElse(async() =>
                    {
                        await DisplayBusyView();
                        await reminderDto.IsEnabled
                            .IfElse(
                                () => AddReminder(reminderDto),
                                () => RemoveReminder(reminderDto))
                            .PipeAsync(SaveReminder);
                        await DismissBusyView();
                    },async() =>
                    {
                        await DisplayAlert(result);
                        await NavigatePrevious();
                    }));
    }

    internal static class ReminderViewModelFactory
    {
        public static ReminderViewModel ReminderViewModel()
            => new(
                GetReminders,
                UpdateReminder,
                TrackException,
                DisplayException,
                RequestAccess,
                AddReminder,
                RemoveReminder,
                Alert.Display,
                NavigateBack,
                DisplayBusyView,
                DismissBusyView);

        private static async Task<IList<ReminderDto>> GetReminders()
            => await Threading.SleepOne()
                .PipeAsync(Repository.GetReminders);

        private static async void TrackException(
            Exception exception)
            => await Track(exception);

        private static async void DisplayException(
            Exception exception)
            => await 
                Track(exception)
                .PipeAsync(DismissBusyView)
                .PipeAsync(() => Display(exception))
                .PipeAsync(NavigateBack);

        private static async Task<Result> RequestAccess()
            => await DependencyService
                .Get<IRequestAccess>()
                .Request();

        private static async Task<ReminderDto> AddReminder(
            ReminderDto reminderDto)
            => await DependencyService
                .Get<IAddReminder>()
                .Add(reminderDto);

        private static async Task<ReminderDto> RemoveReminder(
            ReminderDto reminderDto)
            => await DependencyService
                .Get<IRemoveReminder>()
                .Remove(reminderDto);
    }
}