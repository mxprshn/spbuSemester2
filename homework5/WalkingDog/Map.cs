using System;
using System.IO;

namespace WalkingDog
{
    public class Map : IRenderable
    {
        public int Height { get; }
        public int Width { get; }
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

                        filling[i, j] = currentCharacter;
                    }

                }
            }
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
