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

            Render();
        }

        private void Render()
        {
            Console.CursorVisible = false;
            currentMap.Render();
            walkingDog.Render();
        }

        private void LeftMovement(object sender, EventArgs e)
        {
            walkingDog.MoveLeft();
            Render();
        }

        private void RightMovement(object sender, EventArgs e)
        {
            walkingDog.MoveRight();
            Render();
        }

        private void UpMovement(object sender, EventArgs e)
        {
            walkingDog.MoveUp();
            Render();
        }

        private void DownMovement(object sender, EventArgs e)
        {
            walkingDog.MoveDown();
            Render();
        }

    }
}
