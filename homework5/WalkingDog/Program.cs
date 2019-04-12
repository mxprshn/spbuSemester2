
namespace WalkingDog
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var dogHandler = new DogHandler("..\\..\\Map.txt");

            eventLoop.LeftPressed += dogHandler.LeftDogMovement;
            eventLoop.RightPressed += dogHandler.RightDogMovement;
            eventLoop.UpPressed += dogHandler.UpDogMovement;
            eventLoop.DownPressed += dogHandler.DownDogMovement;

            eventLoop.Run();
        }
    }
}