// ReSharper disable AsyncVoidLambda

using System;
using System.Linq;
using System.Threading.Tasks;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using static System.Console;

using static Elements.Common.Constructors.DateTimeConstructor;
using static Elements.Common.Constructors.GuidConstructor;
using static Elements.Common.Constructors.ListConstructor;
using static Elements.Domain.Models.SectionConstructor;
using static Elements.Domain.Models.ArticleConstructor;
using static Elements.Domain.Models.ReminderConstructor;
using static Elements.Domain.Models.OrderConstructor;
using static Elements.Domain.Models.DisclaimerConstructor;
using static Elements.Persistence.ContextConstructor;

using Guid = System.Guid;

namespace Elements.Persistence
{
    public static partial class Content
    {
        public static async Task Add()
        {
            WriteLine("Seeding database...");
            IList(
                Reminder(
                    Guid(),
                    "Check roof for damage",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Check fascia and trim for deterioration",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Contact an HVAC professional to maintenance the cooling system",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Check water heater for leaks and rust",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Check fire extinguishers",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Clean kitchen exhaust hood and filter",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Repair damaged and uneven driveways, walks, and paths",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Check plumbing fixture shutoff valves to make sure they work",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Clean clothes dryer exhaust duct and damper as well as under the dryer",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Make sure house number is visible from the street for first-responders",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Replace damaged or worn extension cords",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Test smoke and carbon monoxide alarms",
                    DateTime(2022, 3, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Spring,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Check deck and patio for deterioration",
                    DateTime(2022, 6, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Summer,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Check nightlights at the top and bottom of stairs",
                    DateTime(2022, 6, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Summer,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Inspect exterior siding for wear and damage",
                    DateTime(2022, 6, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Summer,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Check window and door locks",
                    DateTime(2022, 6, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Summer,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Check for water leaks",
                    DateTime(2022, 6, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Summer,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Check water hoses and kitchen and laundry room appliances for cracks and bubbles",
                    DateTime(2022, 6, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Summer,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Contact an HVAC professional to maintenance the heating system",
                    DateTime(2022, 9, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Prepare pipes for winter to prevent freezing",
                    DateTime(2022, 9, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Run all gas powered equipment until the fuel is gone",
                    DateTime(2022, 9, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Test emergency generator",
                    DateTime(2022, 9, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Have a chimney sweep maintenance the fireplace and chimney",
                    DateTime(2022, 9, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Remove birds' nests from the chimney and other areas",
                    DateTime(2022, 9, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Verify caulking around doors and windows is adequate to help reduce energy loss",
                    DateTime(2022, 9, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Verify caulking around bathroom fixtures is adequate to help prevent leaks",
                    DateTime(2022, 9, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Clean gutters and downspouts",
                    DateTime(2022, 9, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Fall,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Verify firewood is stored at least 20 feet away from the house",
                    DateTime(2022, 12, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Winter,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Make sure everyone knows how to operate the gas main valve and other shut off valves",
                    DateTime(2022, 12, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Winter,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Verify electrical holiday decorations have tight connections",
                    DateTime(2022, 12, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Winter,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Test AFCI and GFCI devices",
                    DateTime(2022, 12, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Winter,
                    PlatformId.Empty(),
                    false),
                Reminder(
                    Guid(),
                    "Review emergency escape plan with everyone",
                    DateTime(2022, 12, 1, 8, 0, 0, DateTimeKind.Local),
                    Recurrence.Yearly,
                    Season.Winter,
                    PlatformId.Empty(),
                    false))
                .ForEach(async r => await ReminderRepository.Add(r));

            await ReminderRepository
                .GetAll()
                .PipeAsync(reminders =>
                    reminders.ForEachAsync(r =>
                        Task.Run(() => WriteLine("Reminder Id" + r.Id))));

            IList(
                Article(
                    Guid(),
                    "Home",
                    "HomeBackground",
                    IList(
                        Section(
                            Guid(),
                            "Did You Know?",
                            "• A Home Inspection can save you around $14,000 on average?!\n" +
                            "• What's the average cost of a Home Inspection? Just around $400 whoa!",
                            0),
                        Section(
                            Guid(),
                            "Pre-purchase",
                            "Purchasing a home also means buying that home's problems.  When performing a pre-purchase" +
                            " home inspection, we help you discover exactly what you're buying.  Defects discovered during" +
                            " the inspection could help you negotiate to offset the costs of repairs.",
                            1),
                        Section(
                            Guid(),
                            "Pre-listing",
                            "Sometimes selling your home can be as much of a roller coaster ride as buying one." +
                            " Having us perform a pre-listing home inspection can help ensure a quick and smooth transaction." +
                            " You can enter the selling process with confidence you'll have fewer surprises!",
                            2))),
                Article(
                    Guid(),
                    "Mold",
                    "MoldBackground",
                    IList(
                        Section(
                            Guid(),
                            "Did You Know?",
                            "• Mold exposure can cause allergic reactions, asthma, and other issues?!\n" +
                            "• There's no way to eliminate all mold and mold spores indoors. The way to control" +
                            " indoor mold is by controlling moisture.",
                            0),
                        Section(
                            Guid(),
                            "Air Sampling",
                            "We begin the mold inspection process by taking outdoor air samples, which will serve as" +
                            " a control to be used in comparison with the air in your home. Next, we'll collect samples" +
                            " from the interior of your home.",
                            1),
                        Section(
                            Guid(),
                            "Lab Results",
                            "After collecting samples, we'll send them to a lab for analysis. Lab analysis typically takes 24-72 hours." +
                            " The general way to determine if you have a mold problem is if the number of mold spores is higher inside the" +
                            " home than outside, then there is a mold issue in the house.",
                            2))),
                Article(
                    Guid(),
                    "Radon",
                    "RadonBackground",
                    IList(
                        Section(
                            Guid(),
                            "Did You Know?",
                            "• Radon is the second leading cause of lung cancer in the United States and is classified as a" +
                            " \"Class A\" carcinogen according to the EPA?!",
                            0),
                        Section(
                            Guid(),
                            "Radioactive",
                            "Radon is a radioactive element that occurs from the breakdown of uranium in the soil and rocks." +
                            " Radon becomes a risk indoors because as it continues to break down, it emits atomic particles that" +
                            " can alter DNA and increase lung cancer risk upon entering the lungs.",
                            1),
                        Section(
                            Guid(),
                            "Action Level",
                            "1 in 5 homes in the St. Louis area has a radon level at or above the EPA’s “action level” limit of 4 pCi/L" +
                            " (the equivalent of smoking eight cigarettes daily). We perform a Radon test using a Continuous Radon" +
                            " Monitor over 48 hours.",
                            2))),
                Article(
                    Guid(),
                    "Termite",
                    "TermiteBackground",
                    IList(
                        Section(
                            Guid(),
                            "Did You Know?",
                            "• Property damages by termites cause financial losses between three and seven billion dollars annually?!" +
                            " That makes termites more destructive than floods, fires, and tornadoes combined!",
                            0),
                        Section(
                            Guid(),
                            "Signs",
                            "Generally, the first sign of an infestation is the presence of termites swarming near indoor lights or on a window." +
                            " If they're found inside a house, it almost always means that they have infested.",
                            1),
                        Section(
                            Guid(),
                            "Inspection",
                            "The Inspector will examine the interior and exterior areas of your home, checking for visible" +
                            " signs of termite infestation, which generally include: droppings, broken wings, mud tubes," +
                            " and damaged wood.",
                            2))),
                Article(
                    Guid(),
                    "Pool",
                    "PoolBackground",
                    IList(
                        Section(
                            Guid(),
                            "Did You Know?",
                            "• An hour of swimming burns almost as many calories as running but without the risk of impact injuries to bones and joints?!\n" +
                            "• When you swim, your muscles not only get a good workout, but your cardiovascular system does too!",
                            0),
                        Section(
                            Guid(),
                            "Safety",
                            "It's important to ensure that electrical wires are far away from the pool and that walkways around the pool don't pose" +
                            " a hazard leading to trips and slips! Fencing should be of a certain height so kids can't climb in unexpectedly, " +
                            "and the design should pose a challenge to make it more difficult for little ones to climb over.",
                            1),
                        Section(
                            Guid(),
                            "Pump",
                            "The pump is one of the most essential pieces of equipment in your pool. It circulates water around other devices like" +
                            " filters and heaters, which keep the water clean and warm. Without a functioning pump, a pool will not be usable for long." +
                            " It's essential to make sure the pump is working, that it is properly secured, and that the wiring is solid.",
                            2))),
                Article(
                    Guid(),
                    "Waste",
                    "WasteBackground",
                    IList(
                        Section(
                            Guid(),
                            "Did You Know?",
                            "• A 2019 report by the International Risk Management Institute, implies uninsured sewer backup incidents often" +
                            " cost a homeowner $20,000 to $50,000?!",
                            0),
                        Section(
                            Guid(),
                            "Sewer",
                            "We use a special camera to help identify any damage or obstructions that may be present in the main sewer line." +
                            " The camera has a transmitter that can be located using a handheld wand which helps us find any damaged areas.",
                            1),
                        Section(
                            Guid(),
                            "Septic",
                            "One of the most important parts of performing a septic inspection is determining exactly which septic system you have." +
                            "  After this, we check the tanks, pumps, filters, and dispersal systems to ensure everything is in good working order.",
                            2))))
                    .ForEach(async a => await ArticleRepository.Add(a));

            await ArticleRepository
                .GetAll()
                .PipeAsync(articles =>
                    articles.ForEachAsync(a => 
                        Task.Run(() =>
                    {
                        WriteLine("Article Id " + a.Id);
                        a.Sections.ForEach(s => WriteLine("Section Id " + s.Id));
                    })));

            await 
                Disclaimer(
                    Guid(),
                    "The information provided by Elements Home Inspections LLC (\"we,\" \"us,\" or \"our\") " +
                    "on our mobile application is for general informational purposes only. All information " +
                    "on our mobile application is provided in good faith, however we make no representation " +
                    "or warranty of any kind, express or implied, regarding the accuracy, adequacy, validity, " +
                    "reliability, availability, or completeness of any information on our mobile application.\r\n" +
                    "UNDER NO CIRCUMSTANCE SHALL WE HAVE ANY LIABILITY TO YOU FOR ANY LOSS OR DAMAGE OF ANY KIND " +
                    "INCURRED AS A RESULT OF THE USE OF OUR MOBILE APPLICATION OR RELIANCE ON ANY INFORMATION " +
                    "PROVIDED ON OUR MOBILE APPLICATION. YOUR USE OF OUR MOBILE APPLICATION AND YOUR RELIANCE ON ANY " +
                    "INFORMATION ON OUR MOBILE APPLICATION IS SOLELY AT YOUR OWN RISK.",
                    false)
                .Pipe(async d => await DisclaimerRepository.Add(d));

            await DisclaimerRepository
                .Get()
                .PipeAsync(d => Task.Run(
                    () => WriteLine("Disclaimer Id " + d.Id)));

            WriteLine("Press any key to continue");
            ReadKey();
        }
    }

    public static partial class Content
    {
        public static async Task Update()
        {
            await Task.CompletedTask;
        }

        private static async Task One()
        {
            const string one =
                "one";
            if (IsNotSet(one))
            {
                var article =
                    await ArticleRepository
                        .Get("Radon");
                var section =
                    article
                    .Sections
                    .Single(s => s.Order.Equals(Order(1)))
                    .With("New Text");
                await ArticleRepository
                    .Update(article.With(section));
                await Set(new Update(Guid(),one));
            }
        }

        private static async Task Two()
        {
            const string two =
                "two";
            if (IsNotSet(two))
            {
                var article =
                    await ArticleRepository
                        .Get("Termite");
                var section =
                    article
                    .Sections
                    .Single(s => s.Order.Equals(Order(1)))
                    .With("New Text");
                await ArticleRepository
                    .Update(article.With(section));
                await Set(new Update(Guid(),two));
            }
        }

        private static async Task Three()
        {
            const string three =
                "three";
            if (IsNotSet(three))
            {
                var reminder =
                    await ReminderRepository
                        .Get(Guid.Parse(""));
                await ReminderRepository
                    .Update(reminder.With("New Title"));
                await Set(new Update(Guid(),three));
            }
        }

        private static async Task Set(Update update)
        {
            var context = Context();
            await context.Updates.AddAsync(update);
            await context.SaveChangesAsync();
        }

        private static bool IsNotSet(string update)
        {
            var context = Context();
            return !context.Updates
                .Any(u => u.Value.Equals(update));
        }
    }

    public class Update
    {
        public Update(
            Guid id,
            string value)
        {
            Id = id;
            Value = value;
        }

        public Guid Id { get; private set; }
        public string Value { get; private set; }
    }
}