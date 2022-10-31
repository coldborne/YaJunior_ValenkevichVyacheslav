using System;

namespace Aquarium
{
    public class Fish
    {
        private int _dyingRate;
        
        public int Age { get; private set; }
        public ConsoleColor Color { get; private set; }
        public string Name { get; private set; }

        public Fish()
        {
            Age = UserUtils.Random.Next(1,11);
            Color = ConsoleColor.Gray;
            _dyingRate = 1;
            Name = GenerateName();
        }

        public Fish(ConsoleColor color)
        {
            Age = UserUtils.Random.Next(1,11);
            Color = color;
            _dyingRate = 1;
            Name = GenerateName();
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
            Console.WriteLine("______");
            Console.WriteLine($"Возраст - {Age}");
            Console.WriteLine($"Цвет - {Color}");
            Console.WriteLine($"Имя - {Name}");
            Console.WriteLine("_____");
        }
        
        private string GenerateName()
        {
            int nameLength = 5;
            string name = "";
            
            while (name.Length < nameLength)
            {
                Char symbol = (char)UserUtils.Random.Next(97, 123);
                if (Char.IsLetterOrDigit(symbol))
                    name += symbol;
            }
            
            return name;
        }
    }
}