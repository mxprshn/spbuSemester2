using System;
using System.IO;

namespace WalkingDog
{
    public class Map : IRenderable
    {
        public int Height { get; }
        public int Width { get; }
        public int LeftDogSpawnPosition { get; } = -1;
        public int TopDogSpawnPosition { get; } = -1;
        private char[,] filling;

        public char this[int top, int left]
        {
            get
            {
                if (top < 0 || top >= Height || left < 0 || top >= Width)
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
                Height = int.Parse(mapReader.ReadLine());
                Width = int.Parse(mapReader.ReadLine());
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
                            TopDogSpawnPosition = i;
                            LeftDogSpawnPosition = j;
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

                if (TopDogSpawnPosition < 0)
                {
                    throw new MapFormatException("No spawn position for dog found.");
                }
            }
        }

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
