using System.Collections.Generic;
using System.Text;
using Zoo.Entities.Animals;
using Zoo.Entities.Interfaces;
using Zoo.Extensions;

namespace Zoo.Entities
{
    public class Aviary : ICopyable<Aviary>
    {
        private readonly List<Animal> _animals;

        public Aviary(string name, List<Animal> animals)
        {
            _animals = animals;
            Name = name;
        }

        public Aviary(string name)
        {
            _animals = new List<Animal>();
            Name = name;
        }

        public string Name { get; }
        public int AnimalCount => _animals.Count;

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public Aviary Copy()
        {
            return new Aviary(Name, new List<Animal>(_animals.Copy()));
        }

        public override string ToString()
        {
            if (_animals.Count == 0)
            {
                return "Вольер пустой";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Вольер содержит животное - {Name}, в количестве {_animals.Count} особей");

            for (int i = 0; i < _animals.Count; i++)
            {
                stringBuilder.Append($"Особь {i + 1} - ");

                stringBuilder.AppendLine(_animals[i].ToString());
            }

            return stringBuilder.ToString();
        }
    }
}