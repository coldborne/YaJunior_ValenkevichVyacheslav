using System;
using System.Collections.Generic;

namespace Zoo
{
    public class Aviary
    {
        private List<Animal> _animals;

        public Aviary()
        {
            _animals = new List<Animal>();
        }

        public void ShowInfo()
        {
            if (_animals.Count == 0)
            {
                Console.WriteLine("Aviary is empty");
                return;
            }

            Console.WriteLine($"Animal - {AnimalTypes.AnimalsTypes[_animals[0].GetType()]}");
            
            foreach (Animal animal in _animals)
            {
                Console.Write($"Name - {animal.Name}");
                Console.Write(" | ");
                Console.Write($"Sex - {animal.Sex}");
                Console.Write(" | ");
                Console.WriteLine($"Sound - {animal.Sound}");
            }
        }

        public bool TryAddAnimal(Animal animal)
        {
            if (animal == null)
            {
                return false;
            }

            _animals.Add(animal);
            return true;
        }
    }
}