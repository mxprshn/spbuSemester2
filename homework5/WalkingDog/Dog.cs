using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDog
{
    class Dog : IRenderable
    {
        public int LeftPosition { get; private set; }
        public int TopPosition { get; private set; }

        public Dog((int left, int top) spawnPosition)
        {
            LeftPosition = spawnPosition.left;
            TopPosition = spawnPosition.top;
        }

        public void Render()
        {
            var startConsoleLeft = Console.CursorLeft;
            var startConsoleTop = Console.CursorTop;

            Console.CursorLeft = LeftPosition;
            Console.CursorTop = TopPosition;

            Console.Write('@');

            Console.CursorLeft = startConsoleLeft;
            Console.CursorTop = startConsoleTop;
        }
    }
}
