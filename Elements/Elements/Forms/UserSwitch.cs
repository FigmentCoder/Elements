// ReSharper disable InvertIf

using System;
using Xamarin.Forms;

namespace Elements.Forms
{
    /// <summary>
    /// User Switch UserToggled Event won't toggle by setting IsToggled
    /// Avoids Triggering events when IsToggled is set Programatically
    /// </summary>
    public class UserSwitch : Switch
    {
        ToggledSetFlags _toggleSetStatus = ToggledSetFlags.None;
        public event EventHandler<ToggledEventArgs> UserToggled;

        public static readonly BindableProperty ToggledStateFromCodeProperty =
            BindableProperty.Create(
                "ToggledStateFromCode", typeof(bool), typeof(UserSwitch),
                defaultBindingMode: BindingMode.TwoWay,
                defaultValue: default(bool), propertyChanged: OnToggledStateFromCodeChanged);

        public bool ToggledStateFromCode
        {
            get => (bool)GetValue(ToggledStateFromCodeProperty);
            set => SetValue(ToggledStateFromCodeProperty, value);
        }

        private static void OnToggledStateFromCodeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((UserSwitch)bindable).OnToggledStateFromCodeChangedImpl((bool)oldValue, (bool)newValue);
        }

        protected virtual void OnToggledStateFromCodeChangedImpl(bool oldValue, bool newValue)
        {
            if (ToggledStateFromCode != IsToggled)
            {
                _toggleSetStatus = ToggledSetFlags.FromCode;
                IsToggled = ToggledStateFromCode;
            }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsToggled))
            {
                ToggledStateFromCode = IsToggled;

                if (_toggleSetStatus == ToggledSetFlags.None)
                {
                    UserToggled?.Invoke(this, new ToggledEventArgs(IsToggled));
                }
                else
                {
                    _toggleSetStatus = ToggledSetFlags.None;
                }
            }
        }
        internal enum ToggledSetFlags
        {
            None = 0,
            FromCode = 1 << 0,
        }
    }
}