using System;

namespace Aquarium
{
    public class Fish
    {
        public int Age { get; private set; }
        public ConsoleColor Color { get; private set; }

        public Fish()
        {
            Random random = new Random();

            Age = random.Next(11);
            Color = ConsoleColor.Gray;
        }

        public Fish(ConsoleColor color)
        {
            Random random = new Random();

            Age = random.Next(11);
            Color = color;
        }

        private bool TryReduceAge()
        {
            if (Age > 0)
            {
                Age--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}