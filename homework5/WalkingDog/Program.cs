
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