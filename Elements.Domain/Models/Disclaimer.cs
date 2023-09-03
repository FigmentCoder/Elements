// ReSharper disable ConvertToAutoProperty

using System;
using Elements.Common.Types;
using static Elements.Common.Constructors.ExceptionConstructors;

namespace Elements.Domain.Models
{
    public class Disclaimer : Entity
    {
        internal Disclaimer(
            Guid id,
            Message message,
            bool hasDisplayed
        )
        {
            Id = id;
            Message = message;
            HasDisplayed = hasDisplayed;
        }

        private Disclaimer() { }

        private Message _message;
        public Message Message
        {
            get =>
                _message;
            private set =>
                _message = value
                ?? throw NullException(nameof(Message));
        }

        private bool _hasDisplayed;
        public bool HasDisplayed
        {
            get =>
                _hasDisplayed;
            private set =>
                _hasDisplayed = value;
        }

        public bool HasNotDisplayed 
            => !HasDisplayed;

        public Disclaimer With(
            bool hasDisplayed)
            => new(Id, Message, hasDisplayed);
    }

    public static class DisclaimerConstructor
    {
        public static Disclaimer Disclaimer(
            Guid id,
            Message message,
            bool isDisplayed)
            => new(id, message, isDisplayed);
    }
}