using System;

namespace OrganizerCore
{
    public interface IUIDevive
    {
        // contains events for button pressing
        event EventHandler<AnyButtonPressedEventArgs> RaiseButtonOnePressedEvent;

        event EventHandler<AnyButtonPressedEventArgs> RaiseButtonTwoPressedEvent;

        event EventHandler<AnyButtonPressedEventArgs> RaiseButtonThreePressedEvent;

        event EventHandler<AnyButtonPressedEventArgs> RaiseButtonFourPressedEvent;

        event EventHandler<AnyButtonPressedEventArgs> RaiseButtonLeftPressedEvent;

        event EventHandler<AnyButtonPressedEventArgs> RaiseButtonRightPressedEvent;

        event EventHandler<AnyButtonPressedEventArgs> RaiseButtonEscPressedEvnet;

        event EventHandler<AnyButtonPressedEventArgs> RaiseButtonDeletePressedEvnet;

        void GetCommand();
    }
}
