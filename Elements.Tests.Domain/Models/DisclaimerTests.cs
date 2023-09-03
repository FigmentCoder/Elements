using System;

using Xunit;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using Guid = System.Guid;

using static Elements.Common.Constructors.GuidConstructor;
using static Elements.Domain.Models.DisclaimerConstructor;
using static Elements.Domain.Models.MessageConstructor;
using static Elements.Tests.Domain.ExceptionMessages;

namespace Elements.Tests.Domain.Models
{
    public class DisclaimerTests
    {
        private readonly Guid Id = Guid();
        private readonly Message Message = Message("Some Message");

        [Fact]
        public void ConstructorDoesNotThrow()
            => Record.Exception(() =>
                Disclaimer(Id, Message, false))
                    .Pipe(Assert.Null);

        [Fact]
        public void ConstructorGuidEmptyThrows()
            => Assert.Throws<ArgumentOutOfRangeException>(() =>
                    Disclaimer(Guid.Empty, Message, false))
                        .Pipe(e => Assert.Equal(OutOfRange("Id"), e.Message));

        [Fact]
        public void ConstructorMessageNullThrows()
            => Assert.Throws<ArgumentNullException>(() =>
                    Disclaimer(Id, null, false))
                        .Pipe(e => Assert.Equal(Null("Message"), e.Message));

        [Fact]
        public void HasNotDisplayedNegatesHasDisplayed()
        {
            var disclaimer =
                Disclaimer(Id, Message, false);

            Assert.True(disclaimer.HasNotDisplayed);
        }

        [Fact]
        public void WithReturnsNewDisclaimerWithBool()
        {
            var disclaimer =
                Disclaimer(Id, Message, false);

            var disclaimerP =
                disclaimer.With(true);

            Assert.Equal(disclaimer.Id, disclaimerP.Id);
            Assert.Equal(disclaimer.Message, disclaimerP.Message);
            Assert.NotEqual(disclaimer.HasDisplayed, disclaimerP.HasDisplayed);
        }

        [Fact]
        public void PropertiesAreSet()
        {
            var disclaimer =
                Disclaimer(Id, Message, true);

            Assert.Equal(Id, disclaimer.Id);
            Assert.Equal(Message, disclaimer.Message);
            Assert.True(disclaimer.HasDisplayed);
        }

        [Fact]
        public void EqualsIsTrue()
            => Assert.True(
                Disclaimer(Id, Message, false)
                    .Equals(
                Disclaimer(Id, Message("Other"), true)));
    }
}