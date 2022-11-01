using System;
using System.Collections.Generic;

namespace Aquarium
{
    public class Aquarium
    {
        private readonly List<Fish> _fishes;

        public int MaxFishesAmount { get; private set; } = 5;

        public Aquarium()
        {
            _fishes = new List<Fish>();
        }

        public bool TryAddFish()
        {
            if (_fishes.Count < MaxFishesAmount)
            {
                int number = UserUtils.Random.Next(0, 2);

                if (number == 0)
                {
                    Fish fish = CreateFish();
                    _fishes.Add(fish);
                }
                else
                {
                    ConsoleColor color = GetRandomColor();
                    Fish fish = CreateFish(color);
                    _fishes.Add(fish);
                }

                return true;
            }

            Console.WriteLine("В аквариуме максимум рыбок");
            return false;
        }

        public bool TryPullOutRandomFish()
        {
            if (_fishes == null || _fishes.Count == 0)
            {
                Console.WriteLine("Аквариум уже пуст");
                return false;
            }

            int indexOfFish = UserUtils.Random.Next(0, _fishes.Count);

            _fishes.RemoveAt(indexOfFish);

            return true;
        }

        public void ShowAllFishes()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                Console.WriteLine($"{i + 1}-ая");
                _fishes[i].ShowInfo();
            }
        }

        public void CleanAquariumOfDeadFish()
        {
            List<Fish> deadFishes = TryToFindDeadFish();

            foreach (Fish deadFish in deadFishes)
            {
                _fishes.Remove(deadFish);
            }
        }

        public void ReduceFishesAge()
        {
            foreach (Fish fish in _fishes)
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
            return _fishes.FindAll(fish => fish.Age == 0);
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