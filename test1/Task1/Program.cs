using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue();
            queue.Enqueue(10, 1000);
            Console.WriteLine($"{queue.Dequeue()}");
            Console.WriteLine("I don't know what to do here.");
        }
    }
}