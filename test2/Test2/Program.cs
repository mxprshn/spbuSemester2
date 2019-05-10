using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringSet = new SortedSet<List<string>, string>();

            using (var reader = new StreamReader("input.txt"))
            {
                var current = "";

                while ((current = reader.ReadLine()) != null)
                {
                    var words = current.Split();
                    var wordList = new List<string>();

                    foreach (var i in words)
                    {
                        wordList.Add(i);
                    }

                    stringSet.Add(wordList);
                }

            }

            for (var i = 0; i < stringSet.Count; ++i)
            {
                foreach (var j in stringSet[i])
                {
                    Console.Write($"{j} ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
