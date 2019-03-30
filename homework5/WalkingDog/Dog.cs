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
        private Map placementMap;

        public Dog(Map newMap)
        {
            placementMap = newMap;
            LeftPosition = newMap.SpawnPosition.left;
            TopPosition = newMap.SpawnPosition.top;
        }

        public void MoveLeft()
        {
            if (placementMap[(TopPosition, LeftPosition - 1)] == ' ')
            {
                --LeftPosition;
            }
        }

        public void MoveRight()
        {
            if (placementMap[(TopPosition, LeftPosition + 1)] == ' ')
            {
                ++LeftPosition;
            }
        }

        public void MoveUp()
        {
            if (placementMap[(TopPosition - 1, LeftPosition)] == ' ')
            {
                --TopPosition;
            }
        }

        public void MoveDown()
        {
            if (placementMap[(TopPosition + 1, LeftPosition)] == ' ')
            {
                ++TopPosition;
            }
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
