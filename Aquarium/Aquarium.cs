using System;
using System.Collections.Generic;

namespace Aquarium
{
    public class Aquarium
    {
        private readonly List<Fish> _fish;
        private List<Fish> _deadFish;

        public int MaxFishAmount { get; private set; } = 5;

        public Aquarium()
        {
            _fish = new List<Fish>();
            _deadFish = new List<Fish>();
        }

        public bool TryAddFish()
        {
            if (_fish.Count < MaxFishAmount)
            {
                int number = UserUtils.Random.Next(0, 2);

                if (number == 0)
                {
                    Fish fish = CreateFish();
                    _fish.Add(fish);
                }
                else
                {
                    ConsoleColor color = GetRandomColor();
                    Fish fish = CreateFish(color);
                    _fish.Add(fish);
                }

                return true;
            }

            Console.WriteLine("В аквариуме максимум рыбок");
            return false;
        }

        public bool TryPullOutRandomFish()
        {
            if (_fish == null || _fish.Count == 0)
            {
                Console.WriteLine("Аквариум уже пуст");
                return false;
            }

            int indexOfFish = UserUtils.Random.Next(0, _fish.Count);

            _fish.RemoveAt(indexOfFish);

            return true;
        }

        public void ShowAllFish()
        {
            for (int i = 0; i < _fish.Count; i++)
            {
                Console.WriteLine($"{i + 1}-ая");
                _fish[i].ShowInfo();
            }
        }

        public void CleanAquariumOfDeadFish()
        {
            _deadFish = TryToFindDeadFish();

            foreach (Fish deadFish in _deadFish)
            {
                _fish.Remove(deadFish);
            }
            
            _deadFish.Clear();
        }

        public void ReduceFishAge()
        {
            foreach (Fish fish in _fish)
            {
                fish.TryReduceAge();
            }
        }

        public void Init()
        {
            Console.WriteLine("Введите начальное количество рыбок");
            int fishCount = UserUtils.ReadFishCount(this);
            
            for (int i = 0; i < fishCount; i++)
            {
                TryAddFish();
            }
        }

        private ConsoleColor GetRandomColor()
        {
            return (ConsoleColor)UserUtils.Random.Next(1, 16);
        }

        private List<Fish> TryToFindDeadFish()
        {
            return _fish.FindAll(fish => fish.Age == 0);
        }

        private Fish CreateFish(ConsoleColor color)
        {
            return new Fish(color);
        }

        private Fish CreateFish()
        {
            return new Fish();
        }
    }
}