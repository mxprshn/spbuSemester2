using System;

namespace ModifiedHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Set();
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
                    Console.Write("Enter an integer value to add: ");

                    if (int.TryParse(Console.ReadLine(), out int newValue))
                    {
                        if (set.Add(newValue))
                        {
                            Console.WriteLine("Value added.");
                        }
                        else
                        {
                            Console.WriteLine("Value already exists.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input.");
                    }
                }
                else if (command == "2")
                {
                    Console.Write("Enter an integer value to remove: ");

                    if (int.TryParse(Console.ReadLine(), out int newValue))
                    {
                        if (set.Remove(newValue))
                        {
                            Console.WriteLine("Value removed.");
                        }
                        else
                        {
                            Console.WriteLine("Value not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input.");
                    }
                }
                else if (command == "3")
                {
                    Console.Write("Enter an integer value to find: ");

                    if (int.TryParse(Console.ReadLine(), out int newValue))
                    {
                        if (set.Exists(newValue))
                        {
                            Console.WriteLine("Value exists.");
                        }
                        else
                        {
                            Console.WriteLine("Value doesn't exist.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input.");
                    }
                }
            }
        }
    }
}
