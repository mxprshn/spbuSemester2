using System;

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

            for (var i = 0; i < newMap.Height; ++i)
            {
                for (var j = 0; j < newMap.Width; ++j)
                {
                    if (newMap[i, j] == ' ')
                    {
                        TopPosition = i;
                        LeftPosition = j;
                        return;
                    }
                }
            }

            throw new MapFormatException("The map doesn't have any empty spaces.");
        }

        public void MoveLeft()
        {
            if (placementMap[TopPosition, LeftPosition - 1] == ' ')
            {
                --LeftPosition;
            }
        }

        public void MoveRight()
        {
            if (placementMap[TopPosition, LeftPosition + 1] == ' ')
            {
                ++LeftPosition;
            }
        }

        public void MoveUp()
        {
            if (placementMap[TopPosition - 1, LeftPosition] == ' ')
            {
                --TopPosition;
            }
        }

        public void MoveDown()
        {
            if (placementMap[TopPosition + 1, LeftPosition] == ' ')
            {
                ++TopPosition;
            }
        }

        public void Clear()
        {
            RenderSymbol(' ');
        }

        public void Render()
        {
            RenderSymbol('@');
        }

        private void RenderSymbol(char symbol)
        {
            var startConsoleLeft = Console.CursorLeft;
            var startConsoleTop = Console.CursorTop;

            Console.CursorLeft = LeftPosition;
            Console.CursorTop = TopPosition;

            Console.Write(symbol);

            Console.CursorLeft = startConsoleLeft;
            Console.CursorTop = startConsoleTop;
        }
    }
}
