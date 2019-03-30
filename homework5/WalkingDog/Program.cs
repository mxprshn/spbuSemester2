using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDog
{
    class Program
    {
        static void Main(string[] args)
        {
            var myMap = new Map("..\\..\\Map.txt");
            myMap.Render();
            var myDog = new Dog(myMap.SpawnPosition);
            myDog.Render();
            Console.ReadKey();
        }
    }
}
