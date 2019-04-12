using System;
using System.IO;

namespace WalkingDog
{
    /// <summary>
    /// Class representing a map built from symbols.
    /// </summary>
    public class Map : IRenderable
    {
        public int Height { get; }
        public int Width { get; }

        /// <summary>
        /// Position on which a Dog can be spawned.
        /// </summary>
        public (int top, int left) DogSpawnPosition { get; } = (-1, -1);

        /// <summary>
        /// Position standing on which causes some actions.
        /// </summary>
        public (int top, int left) EscapePosition { get; } = (-1, -1);

        private char[,] filling;

        public char this[int top, int left]
        {
            get
            {
                if (top < 0 || top >= Height || left < 0 || left >= Width)
                {
                    return '*';
                }

                return filling[top, left];
            }
        }

        public Map(string filePath)
        {
            using (var mapReader = new StreamReader(filePath))
            {
                if (!int.TryParse(mapReader.ReadLine(), out int height) || !int.TryParse(mapReader.ReadLine(), out int width))
                {
                    throw new MapFormatException("Map size values not found.");
                }

                Height = height;
                Width = width;
                filling = new char[Height, Width];

                for (var i = 0; i < Height; ++i)
                {
                    for (var j = 0; j < Width; ++j)
                    {
                        var currentCharacter = (char)mapReader.Read();

                        while (currentCharacter == '\n' || currentCharacter == '\r')
                        {
                            currentCharacter = (char)mapReader.Read();
                        }

                        if (currentCharacter == '@')
                        {
                            DogSpawnPosition = (i, j);
                            filling[i, j] = ' ';
                        }
                        else if (currentCharacter == '#')
                        {
                            EscapePosition = (i, j);
                            filling[i, j] = ' ';
                        }
                        else
                        {
                            filling[i, j] = currentCharacter;
                        }
                    }
                }

                if (!mapReader.EndOfStream)
                {
                    throw new MapFormatException("The map doesn't match its size.");
                }

                if (DogSpawnPosition.left < 0 || DogSpawnPosition.top < 0)
                {
                    throw new MapFormatException("No spawn position for dog found.");
                }
            }
        }

        /// <summary>
        /// Renders one square of the map.
        /// </summary>
        /// <param name="top">Position of the rendered square from the top of the map.</param>
        /// <param name="left">Position of the rendered square from the left of the map.</param>
        public void Render(int top, int left)
        {
            var startConsoleLeft = Console.CursorLeft;
            var startConsoleTop = Console.CursorTop;

            Console.CursorLeft += left;
            Console.CursorTop += top;

            Console.Write(filling[top, left]);

            Console.CursorLeft = startConsoleLeft;
            Console.CursorTop = startConsoleTop;
        }

        /// <summary>
        /// Renders the map completely as matrix of symbols.
        /// </summary>
        public void Render()
        {
            var startConsoleLeft = Console.CursorLeft;
            var startConsoleTop = Console.CursorTop;

            for (var i = 0; i < Height; ++i)
            {
                for (var j = 0; j < Width; ++j)
                {
                    Console.Write(filling[i, j]);
                }

                Console.WriteLine();
            }

            Console.CursorLeft = startConsoleLeft;
            Console.CursorTop = startConsoleTop;
        }
    }
}