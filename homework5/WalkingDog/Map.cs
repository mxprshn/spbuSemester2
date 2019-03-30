using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDog
{
    public class Map : IRenderable
    {
        public int Height { get; }
        public int Width { get; }
        public (int top, int left) SpawnPosition { get; } = (-1, -1);
        private char[,] filling;

        public char this[(int top, int left) position]
        {
            get
            {
                if (position.top < 0 || position.top >= Height || position.left < 0 || position.top >= Width)
                {
                    return '*';
                }

                return filling[position.top, position.left];
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

                        if (currentCharacter == ' ' && SpawnPosition.top < 0)
                        {
                            SpawnPosition = (i, j);
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
