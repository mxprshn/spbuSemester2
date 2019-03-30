using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            LeftPressed(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            RightPressed(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            UpPressed(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            DownPressed(this, EventArgs.Empty);
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
