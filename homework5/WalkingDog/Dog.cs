using System;

namespace WalkingDog
{
    /// <summary>
    /// Class representing a movable Dog character.
    /// </summary>
    public class Dog : IRenderable
    {
        /// <summary>
        /// Current position from the top border of the area.
        /// </summary>
        public int TopPosition { get; private set; }

        /// <summary>
        /// Current position from the left border of the area.
        /// </summary>
        public int LeftPosition { get; private set; }

        public Dog(int topSpawnPosition, int leftSpawnPosition)
        {
            TopPosition = topSpawnPosition;
            LeftPosition = leftSpawnPosition;
        }

        /// <summary>
        /// Moves the Dog by one position left.
        /// </summary>
        public void MoveLeft() => --LeftPosition;

        /// <summary>
        /// Moves the Dog by one position right.
        /// </summary>
        public void MoveRight() => ++LeftPosition;

        /// <summary>
        /// Moves the Dog by one position up.
        /// </summary>
        public void MoveUp() => --TopPosition;

        /// <summary>
        /// Moves the Dog by one position down.
        /// </summary>
        public void MoveDown() => ++TopPosition;

        /// <summary>
        /// Renders the Dog as '@'.
        /// </summary>
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
