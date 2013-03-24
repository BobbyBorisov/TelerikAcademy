using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput()
        {
            for (int i = 0; i < 3; i++) // The racket will move 3 times faster than the ball
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key.Equals(ConsoleKey.A))
                    {
                        if (this.OnLeftPressed != null)
                        {
                            this.OnLeftPressed(this, new EventArgs());
                        }
                    }

                    if (keyInfo.Key.Equals(ConsoleKey.D))
                    {
                        if (this.OnRightPressed != null)
                        {
                            this.OnRightPressed(this, new EventArgs());
                        }
                    }

                    if (keyInfo.Key.Equals(ConsoleKey.Spacebar))
                    {
                        if (this.OnActionPressed != null)
                        {
                            this.OnActionPressed(this, new EventArgs());
                        }
                    }
                }
            }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnActionPressed;
    }
}
