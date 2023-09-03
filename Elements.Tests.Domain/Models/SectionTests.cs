using System;

using Xunit;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using Guid = System.Guid;

using static Elements.Common.Constructors.GuidConstructor;
using static Elements.Domain.Models.SectionConstructor;
using static Elements.Domain.Models.HeaderConstructor;
using static Elements.Domain.Models.TextConstructor;
using static Elements.Domain.Models.OrderConstructor;
using static Elements.Tests.Domain.ExceptionMessages;

namespace Elements.Tests.Domain.Models
{
    public class SectionTests
    {
        private readonly Guid Id = Guid();
        private readonly Header Header = Header("Header");
        private readonly Text Text = Text("Section");
        private readonly Order Order = Order.Zero();

        [Fact]
        public void ConstructorDoesNotThrow()
            => Record.Exception(() =>
                Section(Id, Header, Text, Order))
                    .Pipe(Assert.Null);

        [Fact]
        public void ConstructorGuidEmptyThrows()
            => Assert.Throws<ArgumentOutOfRangeException>(() =>
                    Section(Guid.Empty, Header, Text, Order))
                        .Pipe(e => Assert.Equal(OutOfRange("Id"), e.Message));

        [Fact]
        public void ConstructorHeaderNullThrows()
            => Assert.Throws<ArgumentNullException>(() => 
                    Section(Id, null, Text, Order))
                        .Pipe(e => Assert.Equal(Null("Header"), e.Message));

        [Fact]
        public void ConstructorTextNullThrows()
            => Assert.Throws<ArgumentNullException>(() =>
                Section(Id, Header, null, Order))
                    .Pipe(e => Assert.Equal(Null("Text"), e.Message));

        [Fact]
        public void ConstructorOrderNullThrows()
            => Assert.Throws<ArgumentNullException>(() =>
                Section(Id, Header, Text, null))
                    .Pipe(e => Assert.Equal(Null("Order"), e.Message));

        [Fact]
        public void PropertiesAreSet()
        {
            var section = 
                Section(Id, Header, Text, Order);

            Assert.Equal(Id, section.Id);
            Assert.Equal(Header, section.Header);
            Assert.Equal(Text, section.Text);
            Assert.Equal(Order, section.Order);
        }

        [Fact]
        public void EqualsIsTrue()
            => Assert.True(
                Section(Id, Header, Text, Order)
                    .Equals(
                Section(Id, Header("Other"), Text("Other"), Order(1))));
    }
}