using System.Windows.Input;
using static Elements.Services.CommandConstructors;

namespace Elements.ViewModels
{
    internal class ScheduleViewModel : ViewModel
    {
        public ScheduleViewModel()
        {
            IsLoadingSelected =
                Command(OnIsLoadingSelected);

            IsNotLoadingSelected =
                Command(OnIsNotLoadingSelected);
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

        public ICommand IsLoadingSelected { get; }
        private void OnIsLoadingSelected()
            => IsLoading = true;

        public ICommand IsNotLoadingSelected { get; }
        private void OnIsNotLoadingSelected()
            => IsLoading = false;
    }

    internal static class ScheduleViewModelConstructor
    {
        public static ScheduleViewModel ScheduleViewModel()
            => new();
    }
}