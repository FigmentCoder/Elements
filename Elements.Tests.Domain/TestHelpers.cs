using FsCheck;
using Elements.Common.Extensions;
using static Elements.Common.Extensions.StringFuncExtensions;

namespace Elements.Tests.Domain
{
    public static class StringGenerator
    {
        public static Arbitrary<string> Generate()
            => Arb.Default.String()
                .Filter(IsNotNullOrEmpty);
    }

    public static class NullEmptyStringGenerator
    {
        public static Arbitrary<string> Generate()
            => Arb.Default.String()
                .Filter(IsNullOrEmpty);
    }

    public static class IntGenerator
    {
        public static Arbitrary<int> Generate()
            => Arb.Default.Int32()
                .Filter(i => i > -1);
    }

    public static class NegativeIntGenerator
    {
        public static Arbitrary<int> Generate
            => Arb.Default.Int32()
                .Filter(i => i < 0);
    }

    public static class ExceptionMessages
    {
        public static string Null(string value)
            => "Value cannot be null. (Parameter "
                .ConcatParameter(value);

        public static string OutOfRange(string value)
            => "Specified argument was out of the range of valid values. (Parameter "
                .ConcatParameter(value);

        private static string ConcatParameter(this string left, string right)
            => left.Concat("'").Concat(right).Concat("')");
    }
}