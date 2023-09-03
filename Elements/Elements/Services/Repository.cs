using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Elements.Common.Extensions;
using Elements.Domain.Models;
using Elements.Models;
using Elements.Persistence;

using static Elements.Domain.Models.ReminderConstructor;
using static Elements.Models.ArticleDtoConstructor;
using static Elements.Models.SectionDtoConstructor;
using static Elements.Models.ReminderDtoConstructor;
using static Elements.Services.DomainExtensions;

namespace Elements.Services
{
    internal static class Repository
	{
        public static async Task<ArticleDto> GetArticle(
            string title)
            => (await ArticleRepository
                .Get(title))
                .Pipe(ToArticleDto);

        public static async Task<IList<ReminderDto>> GetReminders()
            => (await ReminderRepository
                .GetAll())
                .OrderBy(r => r.Season)
                .Select(ToReminderDto)
                .ToList();

        public static async Task UpdateReminder(
            ReminderDto reminderDto)
            => await ReminderRepository
                .Update(reminderDto.ToReminder());
    }

    internal static class DomainExtensions
    {
        public static ArticleDto ToArticleDto(
            Article article)
            => ArticleDto(
                article.Id,
                article.Title,
                article.ImageName,
                article.Sections
                .Select(ToSectionDto)
                .ToList());

        private static SectionDto ToSectionDto(
            Section section)
            => SectionDto(
                section.Id,
                section.Header,
                section.Text,
                section.Order);

        public static ReminderDto ToReminderDto(
            Reminder reminder)
            => ReminderDto(
                reminder.Id,
                reminder.Title,
                reminder.DateTime,
                (RecurrenceDto)reminder.Recurrence,
                (SeasonDto)reminder.Season,
                reminder.PlatformId,
                reminder.IsEnabled);
    }

    internal static class DtoExtensions
    {
        public static Reminder ToReminder(
            this ReminderDto reminderDto)
            => Reminder(
                reminderDto.Id,
                reminderDto.Title,
                reminderDto.DateTime,
                (Recurrence)reminderDto.Recurrence,
                (Season)reminderDto.Season,
                reminderDto.PlatformId,
                reminderDto.IsEnabled);
    }
}