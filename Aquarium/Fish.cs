using System;

namespace Aquarium
{
    public class Fish
    {
        private int _dyingRate;
        private string _name;
        private ConsoleColor _color;
        
        public int Age { get; private set; }
        
        public Fish()
        {
            Age = UserUtils.Random.Next(1, 11);
            _color = ConsoleColor.Gray;
            _dyingRate = 1;
            _name = GenerateName();
        }

        public Fish(ConsoleColor color)
        {
            Age = UserUtils.Random.Next(1, 11);
            _color = color;
            _dyingRate = 1;
            _name = GenerateName();
        }

        public bool TryReduceAge()
        {
            if (Age <= 0)
            {
                return false;
            }

            if (Age >= _dyingRate)
            {
                Age -= _dyingRate;
                return true;
            }

            Age = 0;
            return true;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Возраст - {Age}");
            Console.WriteLine($"Цвет - {_color}");
            Console.WriteLine($"Имя - {_name}");
        }

        private string GenerateName()
        {
            const int nameLength = 5;
            string name = "";

            while (name.Length < nameLength)
            {
                char symbol = (char)UserUtils.Random.Next(97, 123);

                if (char.IsLetterOrDigit(symbol))
                {
                    name += symbol;
                }
            }

            return name;
        }
    }
}