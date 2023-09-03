using System.Collections.Generic;
using Elements.Common.Extensions;
using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Common.Types
{
    public abstract class StringValueObject 
        : ValueObject<string>
    {
        protected StringValueObject(string value)
        {
            if (value.IsNullOrEmpty())
                throw NullException(nameof(value));
            Value = value;
        }

        protected StringValueObject() { }

        protected override IEnumerable<object> 
            GetEqualityComponents()
        {
            yield return Value;
        }
    }
}