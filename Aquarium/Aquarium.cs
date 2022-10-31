using System;
using System.Collections.Generic;

namespace Aquarium
{
    public class Aquarium
    {
        private List<Fish> _fishes;

        public int MaxFishesAmount { get; private set; } = 20;

        public ConsoleColor GetRandomColor()
        {
            return (ConsoleColor)UserUtils.Random.Next(1, 16);
        }

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

        public void PullOutRandomFish()
        {
            int indexOfFish = UserUtils.Random.Next(0, _fishes.Count);

            _fishes.RemoveAt(indexOfFish);
        }

        public void ShowAllFishes()
        {
            foreach (Fish fish in _fishes)
            {
                fish.ShowInfo();
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