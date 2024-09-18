using System;
using System.Collections.Generic;

namespace Aquarium
{
    public class Aquarium
    {
        private readonly List<Fish> _fish;

        public Aquarium()
        {
            _fish = new List<Fish>();
            MaxFishAmount = 5;
        }

        public int MaxFishAmount { get; }

        public void Fill()
        {
            Console.WriteLine("Введите начальное количество рыбок");
            int fishCount = UserUtils.ReadInt(MaxFishAmount);

            for (int i = 0; i < fishCount; i++)
            {
                if (TryAddFish())
                {
                    Console.WriteLine("Новая рыба успешно добавлена");
                }
                else
                {
                    Console.WriteLine("В аквариуме максимум рыбок");
                }
            }
        }

        public bool TryAddFish()
        {
            if (_fish.Count < MaxFishAmount)
            {
                int defualtColorNumber = 0;
                int randomColorNumber = 1;

                int number = UserUtils.GenerateRandomValue(defualtColorNumber, randomColorNumber + 1);

                Fish fish;

                if (number == 0)
                {
                    fish = CreateFish();
                }
                else
                {
                    ConsoleColor color = GetRandomColor();
                    fish = CreateFish(color);
                }

                _fish.Add(fish);

                return true;
            }

            return false;
        }

        public bool TryTakeOutRandomFish()
        {
            if (_fish == null || _fish.Count == 0)
            {
                return false;
            }

            int indexOfFish = UserUtils.GenerateRandomValue(_fish.Count);

            _fish.RemoveAt(indexOfFish);

            return true;
        }

        public void IncreaseFishAge()
        {
            foreach (Fish fish in _fish)
            {
                fish.TryIncreaseAge();
            }
        }

        public void CleanAquariumOfDeadFish()
        {
            List<Fish> deadFish = FindDeadFish();

            foreach (Fish fish in deadFish)
            {
                _fish.Remove(fish);
            }
        }

        public void ShowAllFish()
        {
            for (int fishIndex = 0; fishIndex < _fish.Count; fishIndex++)
            {
                int fishNumber = fishIndex + 1;
                Fish fish = _fish[fishIndex];

                Console.WriteLine($"{fishNumber}-ая рыба: {fish}");
            }
        }

        private Fish CreateFish(ConsoleColor color)
        {
            return new Fish(color);
        }

        private Fish CreateFish()
        {
            return CreateFish(Fish.DefualtColor);
        }

        private ConsoleColor GetRandomColor()
        {
            const int MinColorNumber = 1;
            const int MaxColorNumber = 16;

            return (ConsoleColor)UserUtils.GenerateRandomValue(MinColorNumber, MaxColorNumber + 1);
        }

        private List<Fish> FindDeadFish()
        {
            return _fish.FindAll(fish => fish.IsDead);
        }
    }
}