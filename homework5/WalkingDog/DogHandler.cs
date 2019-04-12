using System;
using System.Windows.Forms;

namespace WalkingDog
{
    /// <summary>
    /// Class for Dog and Map control.
    /// </summary>
    public class DogHandler
    {
        private Map currentMap;
        private Dog walkingDog;

        public DogHandler(string mapPath)
        {
            currentMap = new Map(mapPath);
            walkingDog = new Dog(currentMap.DogSpawnPosition.top, currentMap.DogSpawnPosition.left);

            Console.CursorVisible = false;
            Console.WriteLine("Welcome to Dog Simulator 2019!\n" +
                "Use arrow keys to control the dog.\n" +
                "Press 'Escape' to exit.\n");

            currentMap.Render();
            walkingDog.Render();
        }

        /// <summary>
        /// Checks if the Dog is on EscapePosition and generates a warning window in this case.
        /// </summary>
        private void CheckEscape()
        {
            if ((walkingDog.TopPosition, walkingDog.LeftPosition) == currentMap.EscapePosition)
            {
                MessageBox.Show(":)", "Warning!");
            }
        }

        /// <summary>
        /// Controls left movement of the Dog on event.
        /// </summary>
        /// <param name="sender">Object which invoked the method.</param>
        /// <param name="e">Event arguments.</param>
        public void LeftDogMovement(object sender, EventArgs e)
        {
            if (currentMap[walkingDog.TopPosition, walkingDog.LeftPosition - 1] == ' ')
            {
                currentMap.Render(walkingDog.TopPosition, walkingDog.LeftPosition);
                walkingDog.MoveLeft();
                walkingDog.Render();
            }

            CheckEscape();
        }

        /// <summary>
        /// Controls right movement of the Dog on event.
        /// </summary>
        /// <param name="sender">Object which invoked the method.</param>
        /// <param name="e">Event arguments.</param>
        public void RightDogMovement(object sender, EventArgs e)
        {
            if (currentMap[walkingDog.TopPosition, walkingDog.LeftPosition + 1] == ' ')
            {
                currentMap.Render(walkingDog.TopPosition, walkingDog.LeftPosition);
                walkingDog.MoveRight();
                walkingDog.Render();
            }

            CheckEscape();
        }

        /// <summary>
        /// Controls up movement of the Dog on event.
        /// </summary>
        /// <param name="sender">Object which invoked the method.</param>
        /// <param name="e">Event arguments.</param>
        public void UpDogMovement(object sender, EventArgs e)
        {
            if (currentMap[walkingDog.TopPosition - 1, walkingDog.LeftPosition] == ' ')
            {
                currentMap.Render(walkingDog.TopPosition, walkingDog.LeftPosition);
                walkingDog.MoveUp();
                walkingDog.Render();
            }

            CheckEscape();
        }

        /// <summary>
        /// Controls down movement of the Dog on event.
        /// </summary>
        /// <param name="sender">Object which invoked the method.</param>
        /// <param name="e">Event arguments.</param>
        public void DownDogMovement(object sender, EventArgs e)
        {
            if (currentMap[walkingDog.TopPosition + 1, walkingDog.LeftPosition] == ' ')
            {
                currentMap.Render(walkingDog.TopPosition, walkingDog.LeftPosition);
                walkingDog.MoveDown();
                walkingDog.Render();
            }

            CheckEscape();
        }
    }
}