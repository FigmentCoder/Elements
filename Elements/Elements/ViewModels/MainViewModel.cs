using System;
using System.Threading.Tasks;

using Elements.Common.Extensions;
using Elements.Common.Services;
using Elements.Models;
using Elements.Services;

using static Elements.Common.Constructors.ObjectConstructor;
using static Elements.Common.Services.AsyncCommandConstructors;
using static Elements.Services.Repository;
using static Elements.Services.ExceptionHandler;
using static Elements.Services.Navigation;
using static Elements.Services.ViewNames;
using static Elements.Views.BusyViewExtensions;

namespace Elements.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        private readonly Func<string,object,Task> NavigateTo;
        private readonly Func<string,Task<ArticleDto>> GetArticle;
        private readonly Func<Task> DisplayDisclaimer;
        private readonly Func<Task> UpdateContent;
        private readonly Func<Task> DisplayBusyView;
        private readonly Func<Task> DismissBusyView;

        internal MainViewModel(
            Func<string,object,Task> navigateTo,
            Func<string,Task<ArticleDto>> getArticle,
            Func<Task> displayDisclaimer,
            Func<Task> updateContent,
            Action<Exception> trackException,
            Func<Task> displayBusyView,
            Func<Task> dismissBusyView)
        {
            NavigateTo = navigateTo;
            GetArticle = getArticle;
            DisplayDisclaimer = displayDisclaimer;
            UpdateContent = updateContent;
            DisplayBusyView = displayBusyView;
            DismissBusyView = dismissBusyView;

            ArticleSelected =
                AsyncCommand<string>(
                    OnArticleSelected,
                    trackException);

            ScheduleSelected =
                AsyncCommand(
                    OnScheduleSelected,
                    trackException);

            ReminderSelected =
                AsyncCommand(
                    OnReminderSelected,
                    trackException);

            LoadingSelected =
                AsyncCommand(
                    OnLoadingSelected,
                    trackException);
        }

        private bool _hasLoaded;
        public bool HasLoaded
        {
            get => _hasLoaded;
            set
            {
                _hasLoaded = value;
                OnPropertyChanged(nameof(HasLoaded));
            }
        }

        public IAsyncCommand LoadingSelected { get; }
        private async Task OnLoadingSelected()
        {
            if (!HasLoaded)
            {
                await 
                 OnDisplayDisclaimerSelected()
                     .PipeAsync(
                 OnUpdateContentSelected);
                HasLoaded = true;
            }
        }

        private async Task OnDisplayDisclaimerSelected()
            => await DisplayDisclaimer();

        private async Task OnUpdateContentSelected()
        {
            await DisplayBusyView();
            await UpdateContent();
            await DismissBusyView();
        }

        public IAsyncCommand<string> ArticleSelected { get; }
        private async Task OnArticleSelected(string title)
            => await
                GetArticle(title)
                    .PipeAsync(article =>
                NavigateTo(ArticleView, article));

        public IAsyncCommand ScheduleSelected { get; }
        private async Task OnScheduleSelected()
            => await NavigateTo(ScheduleView, None);

        public IAsyncCommand ReminderSelected { get; }
        private async Task OnReminderSelected()
            => await NavigateTo(ReminderView, None);
    }

    internal static class MainViewModelFactory
    {
        public static MainViewModel MainViewModel()
            => new (
                NavigateTo,
                GetArticle,
                Disclaimer.Display,
                Content.Update,
                TrackException,
                DisplayBusyView,
                DismissBusyView);

        private static async Task NavigateTo(
            string destination,
            object @object)
            => await Navigate(
                MainPageView, destination, @object);

        private static async void TrackException(
            Exception exception)
            => await Track(exception);
    }
}