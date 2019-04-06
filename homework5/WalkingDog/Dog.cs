using System;

namespace WalkingDog
{
    class Dog : IRenderable
    {
        public int TopPosition { get; private set; }
        public int LeftPosition { get; private set; }

        public Dog(int topSpawnPosition, int leftSpawnPosition)
        {
            TopPosition = topSpawnPosition;
            LeftPosition = leftSpawnPosition;
        }

        public void MoveLeft() => --LeftPosition;
        public void MoveRight() => ++LeftPosition;
        public void MoveUp() => --TopPosition;
        public void MoveDown() => ++TopPosition;

        public void Render()
        {
            var startConsoleLeft = Console.CursorLeft;
            var startConsoleTop = Console.CursorTop;

            Console.CursorLeft += LeftPosition;
            Console.CursorTop += TopPosition;

            var startColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write('@');

            Console.ForegroundColor = startColor;

            Console.CursorLeft = startConsoleLeft;
            Console.CursorTop = startConsoleTop;
        }
    }
}
