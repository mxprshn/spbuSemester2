using System;

namespace ModifiedHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var jenkinsHash = new JenkinsHash();
            var test = new Set(jenkinsHash);
            UserInterface(test);
        }

        static void UserInterface(Set set)
        {
            Console.WriteLine("0 - Exit; 1 - Add a value; 2 - Remove a value; 3 - Check a value for existence\n");
            string command = "";

            while (command != "0")
            {
                command = Console.ReadLine();

                if (command == "1")
                {
                    Console.Write("Enter a value to add: ");

                    if (set.Add(Console.ReadLine()))
                    {
                        Console.WriteLine("Value added.");
                    }
                    else
                    {
                        Console.WriteLine("Value already exists.");
                    }
                }
                else if (command == "2")
                {
                    Console.Write("Enter a value to remove: ");

                    if (set.Remove(Console.ReadLine()))
                    {
                        Console.WriteLine("Value removed.");
                    }
                    else
                    {
                        Console.WriteLine("Value not found.");
                    }

                }
                else if (command == "3")
                {
                    Console.Write("Enter a value to find: ");

                    if (set.Exists(Console.ReadLine()))
                    {
                        Console.WriteLine("Value exists.");
                    }
                    else
                    {
                        Console.WriteLine("Value doesn't exist.");
                    }

                }
            }
        }
    }
}
