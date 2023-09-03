using System;
using System.Collections.Generic;
using System.Linq;

using Elements.Common.Extensions;

using static System.String;

namespace Elements.Common.Types
{
    public class Result : ValueObject<string>
    {
        private Result(string value)
            : base(value) { }

        internal static Result New(string value)
            => value.IsNull()
                ? Empty
                : new Result(value);

        public static Result Empty
            = New(string.Empty);

        public static Result Success
            = New("Success");

        public static Result Failure
            = New("Failure");

        public static Result Granted
            = New("Granted");

        public static Result Denied
            = New("Denied");

        public bool IsSuccess()
            => Value.StartsWith(Success);

        public bool IsNotSuccess()
            => !Value.StartsWith(Success);

        public bool IsGranted()
            => Value.StartsWith(Granted);

        public bool IsNotGranted()
            => !Value.StartsWith(Granted);

        public Result Concat(Exception exception)
            => Value + exception;

        public Result ConcatS(Exception exception)
            => Value + " " + exception;

        public Result Concat(Result result)
            => Value + result;

        public Result ConcatS(Result result)
            => Value + " " + result;

        public bool StartsWith(Result result)
            => Value.StartsWith(result.Value);

        public static bool IsNullOrEmpty(Result result)
            => result.IsNull() || result.Equals(Empty);

        public static implicit operator Result(string value)
            => New(value);

        public static implicit operator string(Result result)
            => result.IsNull()
                ? string.Empty
                : result.Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    public static class ResultConstructors
    {
        public static Result Result(string value)
            => Types.Result.New(value);

        public static Result Success
            = Types.Result.Success;

        public static Result Failure
            = Types.Result.Failure;

        public static Result Granted
            = Types.Result.Granted;

        public static Result Denied
            = Types.Result.Denied;
    }

    public static class ResultExtensions
    {
        public static Result Aggregate(this IEnumerable<Result> results)
            => results.Aggregate((left, right) => left + right);

        public static Result AggregateS(this IEnumerable<Result> results)
            => Join(" ", results);

        public static Result Aggregate(this IEnumerable<Result> results, Func<Result, bool> predicate)
            => results.Where(predicate).Aggregate();

        public static Result AggregateS(this IEnumerable<Result> results, Func<Result, bool> predicate)
            => results.Where(predicate).AggregateS();

        public static Result Successes(this IEnumerable<Result> results)
            => results.AggregateS(r => r.IsSuccess());

        public static Result Failures(this IEnumerable<Result> results)
            => results.AggregateS(r => r.IsNotSuccess());
    }
}