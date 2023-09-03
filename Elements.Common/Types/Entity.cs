using System;
using Elements.Common.Extensions;
using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Common.Types
{
    public abstract class Entity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            protected set
            {
                if (value.IsEmpty())
                    throw OutOfRangeException(nameof(Id));
                _id = value;
            }
        }

        protected virtual object Actual => this;

        public override bool Equals(object obj)
        {
            if (obj is not Entity other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Actual.GetType() != other.Actual.GetType())
                return false;

            if (Id == Guid.Empty || other.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
            => !(a == b);

        public override int GetHashCode()
            => (Actual.GetType()
                .ToString() + Id)
                .GetHashCode();
    }
}