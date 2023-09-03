using System;
using System.Collections.Generic;
using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Common.Types
{
    public abstract class IntValueObject : 
        ValueObject<int>, 
        IComparable<IntValueObject>
    {
        protected IntValueObject(int value)
        {
            if (value < 0)
                throw OutOfRangeException(nameof(value));
            Value = value;
        }

        protected IntValueObject() { }

        protected override IEnumerable<object> 
            GetEqualityComponents()
        {
            yield return Value;
        }

        public int CompareTo(IntValueObject other)
            => Value.CompareTo(other.Value);
    }
}