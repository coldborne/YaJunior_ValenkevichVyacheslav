using System;

namespace Aquarium
{
    public class Fish
    {
        private readonly int MaxAge;

        private int _dyingRate;
        private string _name;
        private ConsoleColor _color;

        public Fish()
        {
            const int MinAge = 1;
            MaxAge = 10;

            _dyingRate = 1;
            _name = GeneratorFishNames.GenerateFishName();
            _color = DefualtColor;
            Age = UserUtils.GetRandomValue(MinAge, MaxAge);
        }

        public Fish(ConsoleColor color) : this()
        {
            _color = color;
        }

        public static ConsoleColor DefualtColor { get; } = ConsoleColor.Gray;
        public int Age { get; private set; }
        public bool IsDead => Age == MaxAge;

        public bool TryIncreaseAge()
        {
            if (Age == MaxAge)
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