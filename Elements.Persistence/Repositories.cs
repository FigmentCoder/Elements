using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Elements.Domain.Models;

using static Elements.Persistence.ContextConstructor;

namespace Elements.Persistence
{
    public static class ArticleRepository
    {
        public static async Task Add(Article article)
        {
            var context = Context();
            await context.Articles.AddAsync(article);
            await context.SaveChangesAsync();
        }

        public static async Task Update(Article article)
        {
            var context = Context();
            context.Articles.Update(article);
            await context.SaveChangesAsync();
        }

        public static async Task<Article> Get(Title title)
        {
            var context = Context();
            return await context.Articles
                .AsNoTracking()
                .Include(a => a.Sections)
                .SingleAsync(a => a.Title.Value.Equals(title.Value));
        }

        public static async Task<IList<Article>> GetAll()
        {
            var context = Context();
            return await context.Articles
                .AsNoTracking()
                .Include(a => a.Sections)
                .ToListAsync();
        }
    }

    public static class ReminderRepository
    {
        public static async Task Add(Reminder reminder)
        {
            var context = Context();
            await context.Reminders.AddAsync(reminder);
            await context.SaveChangesAsync();
        }

        public static async Task Update(Reminder reminder)
        {
            var context = Context();
            context.Reminders.Update(reminder);
            await context.SaveChangesAsync();
        }

        public static async Task<Reminder> Get(Guid id)
        {
            var context = Context();
            return await context.Reminders
                .AsNoTracking()
                .SingleAsync(a => a.Id.Equals(id));
        }

        public static async Task<IList<Reminder>> GetAll()
        {
            var context = Context();
            return await context.Reminders
                .AsNoTracking()
                .ToListAsync();
        }
    }

    public static class DisclaimerRepository
    {
        public static async Task Add(Disclaimer disclaimer)
        {
            var context = Context();
            await context.Disclaimers.AddAsync(disclaimer);
            await context.SaveChangesAsync();
        }

        public static async Task Update(Disclaimer disclaimer)
        {
            var context = Context();
            context.Disclaimers.Update(disclaimer);
            await context.SaveChangesAsync();
        }

        public static async Task<Disclaimer> Get()
        {
            var context = Context();
            return await context.Disclaimers
                .AsNoTracking()
                .SingleAsync();
        }
    }
}