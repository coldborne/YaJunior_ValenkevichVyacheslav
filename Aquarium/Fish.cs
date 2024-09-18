using System;

namespace Aquarium
{
    public class Fish
    {
        private readonly int _maxAge;

        private int _dyingRate;
        private string _name;
        private ConsoleColor _color;

        public Fish()
        {
            int minAge = 1;
            _maxAge = 10;

            _dyingRate = 1;
            _name = GeneratorFishNames.GenerateFishName();
            _color = DefualtColor;
            Age = UserUtils.GenerateRandomValue(minAge, _maxAge);
        }

        public Fish(ConsoleColor color) : this()
        {
            _color = color;
        }

        public static ConsoleColor DefualtColor { get; } = ConsoleColor.Gray;
        public int Age { get; private set; }
        public bool IsDead => Age == _maxAge;

        public bool TryIncreaseAge()
        {
            if (Age == _maxAge)
            {
                return false;
            }

            Age += _dyingRate;
            return true;
        }

        public override string ToString()
        {
            return $"Возраст - {Age}, Цвет - {_color}, Имя - {_name}";
        }
    }
}