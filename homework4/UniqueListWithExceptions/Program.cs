using System;

namespace UniqueListWithExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new UniqueList();
            UserInterface(list);
        }

        static void UserInterface(UniqueList list)
        {
            string commandCode = "";
            Console.WriteLine("0 -- Exit;\n" +
                "1 -- Insert at the beginning\n" +
                "2 -- Insert after another\n" +
                "3 -- Remove the first element\n" +
                "4 -- Remove from specific position\n" +
                "5 -- Remove by value\n" +
                "6 -- Print the list\n");

            while (commandCode != "0")
            {
                commandCode = Console.ReadLine();

                try
                {
                    switch (commandCode)
                    {
                        case "1":
                            {
                                Console.Write("Enter the value: ");
                                string value = Console.ReadLine();
                                list.InsertFirst(value);
                                break;
                            }
                        case "2":
                            {
                                Console.Write("Enter the position of previous element: ");
                                int position = int.Parse(Console.ReadLine());
                                Console.Write("Enter the value: ");
                                string value = Console.ReadLine();
                                list.InsertAfter(value, position);
                                break;
                            }
                        case "3":
                            {
                                list.RemoveFirst();
                                break;
                            }
                        case "4":
                            {
                                Console.Write("Enter the position of element: ");
                                int position = int.Parse(Console.ReadLine());
                                list.Remove(position);
                                break;
                            }
                        case "5":
                            {
                                Console.Write("Enter the value: ");
                                string value = Console.ReadLine();
                                list.Remove(value);
                                break;
                            }
                        case "6":
                            {
                                if (list.Length == 0)
                                {
                                    Console.WriteLine($"The list is empty.");
                                }

                                for (var i = 0; i < list.Length; ++i)
                                {
                                    Console.WriteLine($"{list[i]}");
                                }

                                break;
                            }
                    }
                }

                catch (ExistingElementInsertionException)
                {
                    Console.WriteLine("Element already exits.");
                }

                catch (NotExistingElementRemovalException)
                {
                    Console.WriteLine("This element doesn't exist.");
                }

                catch (IncorrectIndexException)
                {
                    Console.WriteLine("Incorrect value of index.");
                }

                catch (EmptyListOperationException)
                {
                    Console.WriteLine("The list was empty.");
                }

                catch (NotExistingElementRequestException)
                {
                    Console.WriteLine("This element doesn't exist.");
                }
            }
        }
    }
}
