using System;

namespace WalkingDog
{
    public class DogHandler
    {
        private Map currentMap;
        private Dog walkingDog;

        public DogHandler(EventLoop eventLoop)
        {
            currentMap = new Map("..\\..\\Map.txt");
            walkingDog = new Dog(currentMap);

            eventLoop.LeftPressed += LeftMovement;
            eventLoop.RightPressed += RightMovement;
            eventLoop.UpPressed += UpMovement;
            eventLoop.DownPressed += DownMovement;

            Console.CursorVisible = false;
            Console.Title = "Dog Simulator 2019";
            currentMap.Render();
            walkingDog.Render();
        }

        private void LeftMovement(object sender, EventArgs e)
        {
            walkingDog.Clear();
            walkingDog.MoveLeft();
            walkingDog.Render();
        }

        private void RightMovement(object sender, EventArgs e)
        {
            walkingDog.Clear();
            walkingDog.MoveRight();
            walkingDog.Render();
        }

        private void UpMovement(object sender, EventArgs e)
        {
            walkingDog.Clear();
            walkingDog.MoveUp();
            walkingDog.Render();
        }

        private void DownMovement(object sender, EventArgs e)
        {
            walkingDog.Clear();
            walkingDog.MoveDown();
            walkingDog.Render();
        }
    }
}
