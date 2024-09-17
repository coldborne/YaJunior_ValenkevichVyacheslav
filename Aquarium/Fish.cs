using System;

namespace Aquarium
{
    public class Fish
    {
        private int _dyingRate;
        private string _name;
        private ConsoleColor _color;

        public Fish()
        {
            const int MinAge = 1;
            const int MaxAge = 10;

            _dyingRate = 1;
            _name = GenerateFishName();
            _color = ConsoleColor.Gray;
            Age = UserUtils.GetRandomValue(MinAge, MaxAge + 1);
        }

        public Fish(ConsoleColor color) : this()
        {
            _color = color;
        }

        public int Age { get; private set; }

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

        public override string ToString()
        {
            return $"Возраст - {Age}, Цвет - {_color}, Имя - {_name}";
        }

        private string GenerateFishName()
        {
            const int nameLength = 5;
            const int StartSymbolIndex = 97;
            const int EndSymbolIndex = 122;

            string name = "";

            while (name.Length < nameLength)
            {
                char symbol = (char)UserUtils.GetRandomValue(StartSymbolIndex, EndSymbolIndex + 1);

                if (char.IsLetterOrDigit(symbol))
                {
                    name += symbol;
                }
            }

            return name;
        }
    }
}