using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Set test = new Set();
            Console.WriteLine("0 - Exit; 1 - Add a value; 2 - Remove a value; 3 - Check a value for existence\n");
            string command = "";

            while (command != "0")
            {
                command = Console.ReadLine();

                if (command == "1")
                {
                    Console.Write("Enter a value to add: ");
                    Console.WriteLine($"{test.Add(int.Parse(Console.ReadLine()))}");
                }
                else if (command == "2")
                {
                    Console.Write("Enter a value to remove: ");
                    Console.WriteLine($"{test.Remove(int.Parse(Console.ReadLine()))}");
                }
                else if (command == "3")
                {
                    Console.Write("Enter a value to find: ");
                    Console.WriteLine($"{test.Exists(int.Parse(Console.ReadLine()))}");
                }
            }
        }
    }
}
