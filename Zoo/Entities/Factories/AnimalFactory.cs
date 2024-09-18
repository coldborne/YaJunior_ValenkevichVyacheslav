using Zoo.Entities.Animals;

namespace Zoo.Entities.Factories
{
    public class AnimalFactory
    {
        public Capybara CreateCapybara(string name, string gender, string sound)
        {
            return new Capybara(name, gender, sound);
        }

        public Cat CreateCat(string name, string gender, string sound)
        {
            return new Cat(name, gender, sound);
        }

        public Giraffe CreateGiraffe(string name, string gender, string sound, double neckLength)
        {
            return new Giraffe(name, gender, sound, neckLength);
        }

        public Penguin CreatePenguin(string name, string gender, string sound)
        {
            return new Penguin(name, gender, sound);
        }
    }
}