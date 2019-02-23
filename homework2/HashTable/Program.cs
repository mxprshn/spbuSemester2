using System;
using SinglyLinkedList;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            List test = new List();
            test.Insert(77);
            test.Insert(11);
            test.Insert(22);
            test.Insert(14);
            test.RemoveLast();
            test.Remove(0);
            test.Remove(1);
            test.Remove(1);

        }
    }
}
