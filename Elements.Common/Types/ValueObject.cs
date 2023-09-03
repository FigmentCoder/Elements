using System.Collections.Generic;
using System.Linq;

namespace Elements.Common.Types
{
    public abstract class ValueObject<T>
    {
        protected ValueObject(T value)
            => Value = value;

        protected ValueObject() { }

        public T Value { get; protected set; }

        public override string ToString()
            => Value.ToString();

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var valueObject = (ValueObject<T>)obj;

            return GetEqualityComponents()
                .SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
            => GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + 
                        (obj?.GetHashCode() ?? 0);
                    }
                });

        public static bool operator ==(
            ValueObject<T> a,
            ValueObject<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(
            ValueObject<T> a,
            ValueObject<T> b)
            => !(a == b);
    }
}