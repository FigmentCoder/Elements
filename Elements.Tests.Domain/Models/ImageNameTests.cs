// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable EqualExpressionComparison

using System;

using Xunit;
using FsCheck.Xunit;

using Elements.Common.Extensions;
using Elements.Domain.Models;

using static Elements.Domain.Models.ImageNameConstructor;

namespace Elements.Tests.Domain.Models
{
    public class ImageNameTests
    {
        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ConstructorDoesNotThrow(string value)
            => Record.Exception(() => ImageName(value))
                .Pipe(Assert.Null);

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ConstructorThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => ImageName(value));

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorImageNameFromString(string value)
        {
            ImageName imageName = value;

            Assert.Equal(value, imageName.Value);
        }

        [Property(Arbitrary = new[] { typeof(NullEmptyStringGenerator) })]
        public void ImplicitOperatorImageNameFromNullEmptyStringThrows(string value)
            => Assert.Throws<ArgumentNullException>(
                () => { ImageName imageName = value; });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ImplicitOperatorStringFromImageName(string value)
        {
            var imageName = ImageName(value);

            string stringFromImageName = imageName;

            Assert.Equal(imageName.Value, stringFromImageName);
        }

        [Fact]
        public void ImplicitOperatorStringFromNullImageNameThrows()
        => Assert.Throws<ArgumentNullException>(
            () =>
            {
                ImageName imageName = null;
                string stringFromImageName = imageName;
            });

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void ToStringSucceeds(string value)
            => Assert.Equal(
                ImageName(value).Value,
                ImageName(value).ToString());

        [Property(Arbitrary = new[] { typeof(StringGenerator) })]
        public void EqualsIsTrue(string value)
            => Assert.True(
                ImageName(value).Equals(ImageName(value)));
    }
}