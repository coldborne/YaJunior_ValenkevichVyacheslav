namespace Zoo
{
    public enum Sex
    {
        male,
        female
    }
    
    public enum Animals
    {
        Capybara,
        Cat,
        Zebra,
        SecretaryBird,
        Platypus
    }

    public abstract class Animal
    {
        public string Name { get; }
        public Sex Sex { get; }
        public AnimalSound.Sounds Sound { get; }

        protected Animal(AnimalSound sound)
        {
            Name = GenerateName();
            
            Sound = sound.GetSound();

            int randomSexAnimal = RandomValuesGenerator.GenerateRandomNumber(0, 1);

            switch (randomSexAnimal)
            {
                case 0:
                    Sex = Sex.female;
                    break;
                case 1:
                    Sex = Sex.male;
                    break;
            }
        }
        
        private string GenerateName()
        {
            const int nameLength = 5;
            string name = "";

            while (name.Length < nameLength)
            {
                char symbol = (char)RandomValuesGenerator.GenerateRandomNumber(97, 122);

                if (char.IsLetterOrDigit(symbol))
                {
                    name += symbol;
                }
            }

            return name;
        }
    }
    
    public class Capybara : Animal
    {
        public Capybara(CapybaraSound capybaraSound) : base(capybaraSound)
        {
        }
    }

    public class Cat : Animal
    {
        public Cat(CatSound catSound) : base(catSound)
        {
        }
    }

    public class Zebra : Animal
    {
        public Zebra(ZebraSound zebraSound) : base(zebraSound)
        {
        }
    }
    
    public class SecretaryBird : Animal
    {
        public SecretaryBird(SecretaryBirdSound secretaryBird) : base(secretaryBird)
        {
        }
    }
    
    public class Platypus : Animal
    {
        public Platypus(PlatypusSound platypusSound) : base(platypusSound)
        {
        }
    }
}