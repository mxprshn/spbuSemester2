using System;

namespace WalkingDog
{
    public class EventLoop
    {
        public event EventHandler<EventArgs> LeftPressed;
        public event EventHandler<EventArgs> RightPressed;
        public event EventHandler<EventArgs> UpPressed;
        public event EventHandler<EventArgs> DownPressed;

        public void Run()
        {
            while (true)
            {
                var keyPressed = Console.ReadKey(true);

                switch (keyPressed.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            LeftPressed?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            RightPressed?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            UpPressed?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            DownPressed?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }
            }
        }
    }
}
