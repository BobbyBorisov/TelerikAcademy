using System;

namespace OrganizerCore
{
    public class Keyboard : IUIDevive
    {
        public event EventHandler<AnyButtonPressedEventArgs> RaiseButtonOnePressedEvent; // 1

        public event EventHandler<AnyButtonPressedEventArgs> RaiseButtonTwoPressedEvent; // 2

        public event EventHandler<AnyButtonPressedEventArgs> RaiseButtonThreePressedEvent; // 3

        public event EventHandler<AnyButtonPressedEventArgs> RaiseButtonFourPressedEvent; // 4

        public event EventHandler<AnyButtonPressedEventArgs> RaiseButtonLeftPressedEvent; // <- Left Arrow

        public event EventHandler<AnyButtonPressedEventArgs> RaiseButtonRightPressedEvent; // -> Right Arrow

        public event EventHandler<AnyButtonPressedEventArgs> RaiseButtonEscPressedEvnet; // ESC

        public event EventHandler<AnyButtonPressedEventArgs> RaiseButtonDeletePressedEvnet; // ESC

        public void GetCommand()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.D1)
                {
                    if (this.RaiseButtonOnePressedEvent != null)
                    {
                        this.RaiseButtonOnePressedEvent(this, new AnyButtonPressedEventArgs());
                    }
                }
                else if (keyPressed.Key == ConsoleKey.D2)
                {
                    if (this.RaiseButtonTwoPressedEvent != null)
                    {
                        this.RaiseButtonTwoPressedEvent(this, new AnyButtonPressedEventArgs());
                    }
                }
                else if (keyPressed.Key == ConsoleKey.D3)
                {
                    if (this.RaiseButtonThreePressedEvent != null)
                    {
                        this.RaiseButtonThreePressedEvent(this, new AnyButtonPressedEventArgs());
                    }
                }
                else if (keyPressed.Key == ConsoleKey.D4)
                {
                    if (this.RaiseButtonFourPressedEvent != null)
                    {
                        this.RaiseButtonFourPressedEvent(this, new AnyButtonPressedEventArgs());
                    }
                }
                else if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (this.RaiseButtonLeftPressedEvent != null)
                    {
                        this.RaiseButtonLeftPressedEvent(this, new AnyButtonPressedEventArgs());
                    }
                }
                else if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (this.RaiseButtonRightPressedEvent != null)
                    {
                        this.RaiseButtonRightPressedEvent(this, new AnyButtonPressedEventArgs());
                    }
                }
                else if (keyPressed.Key == ConsoleKey.Escape)
                {
                    if (this.RaiseButtonEscPressedEvnet != null)
                    {
                        this.RaiseButtonEscPressedEvnet(this, new AnyButtonPressedEventArgs());
                    }
                }
                else if (keyPressed.Key == ConsoleKey.Delete)
                {
                    if (this.RaiseButtonDeletePressedEvnet != null)
                    {
                        this.RaiseButtonDeletePressedEvnet(this, new AnyButtonPressedEventArgs());
                    }
                }
            }
        }
    }
}
