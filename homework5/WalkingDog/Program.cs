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
            var eventLoop = new EventLoop();
            var dogHandler = new DogHandler(eventLoop);
            eventLoop.Run();
        }
    }
}