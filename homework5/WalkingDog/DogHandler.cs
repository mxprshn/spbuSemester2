using System;

namespace WalkingDog
{
    public class DogHandler
    {
        private Map currentMap;
        private Dog walkingDog;

        public DogHandler()
        {
            currentMap = new Map("..\\..\\Map.txt");
            walkingDog = new Dog(currentMap.TopDogSpawnPosition, currentMap.LeftDogSpawnPosition);

            Console.CursorVisible = false;
            Console.WriteLine("Welcome to Dog Simulator 2019!\n" +
                "Use arrow keys to control the dog.\n" +
                "Press 'Escape' to exit.\n");

            currentMap.Render();
            walkingDog.Render();
        }

        public void LeftDogMovement(object sender, EventArgs e)
        {
            currentMap.Render(walkingDog.TopPosition, walkingDog.LeftPosition);

            if (currentMap[walkingDog.TopPosition, walkingDog.LeftPosition - 1] == ' ')
            {
                walkingDog.MoveLeft();
            }

            walkingDog.Render();
        }

        public void RightDogMovement(object sender, EventArgs e)
        {
            currentMap.Render(walkingDog.TopPosition, walkingDog.LeftPosition);

            if (currentMap[walkingDog.TopPosition, walkingDog.LeftPosition + 1] == ' ')
            {
                walkingDog.MoveRight();
            }

            walkingDog.Render();
        }

        public void UpDogMovement(object sender, EventArgs e)
        {
            currentMap.Render(walkingDog.TopPosition, walkingDog.LeftPosition);

            if (currentMap[walkingDog.TopPosition - 1, walkingDog.LeftPosition] == ' ')
            {
                walkingDog.MoveUp();
            }

            walkingDog.Render();
        }

        public void DownDogMovement(object sender, EventArgs e)
        {
            currentMap.Render(walkingDog.TopPosition, walkingDog.LeftPosition);

            if (currentMap[walkingDog.TopPosition + 1, walkingDog.LeftPosition] == ' ')
            {
                walkingDog.MoveDown();
            }

            walkingDog.Render();
        }
    }
}
