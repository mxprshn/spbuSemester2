using System;

namespace ModifiedHashTable
{
    class Program
    {
        private static void Main(string[] args)
        {
            Set testSet;
            Console.WriteLine("Choose a hash function which will be used in set implementation:");
            Console.WriteLine("0 -- Exit; 1 -- Rolling hash; 2 - Jenkins hash; 3 -- FNV hash");
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    {
                        testSet = new Set(new RollingHash());                        
                        break;
                    }
                case "2":
                    {
                        testSet = new Set(new JenkinsHash());
                        break;
                    }
                case "3":
                    {
                        testSet = new Set(new FNVHash());
                        break;
                    }
                default:
                    {
                        return;
                    }
                    
            }

            Console.WriteLine("Set created.");
            UserInterface(testSet);
        }

        private static void UserInterface(Set set)
        {
            Console.WriteLine("0 -- Exit; 1 - Add a value; 2 -- Remove a value; 3 -- Check a value for existence");
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
