using System;

namespace Zoo
{
    public static class AviariesGenerator
    {
        
        
        public static Aviary TryGenerateAviary(Type type)
        {
            if (AnimalTypes.AnimalsTypes.ContainsKey(type) == false)
            {
                return null;
            }

            int maxAnimalAmount = 10;
            int minAnimalAmount = 5;
            int animalCount = RandomValuesGenerator.GenerateRandomNumber(minAnimalAmount, maxAnimalAmount);

            Aviary aviary = new Aviary();

            Animals animal = AnimalTypes.AnimalsTypes[type];

            switch (animal)
            {
                case Animals.Capybara:
                    FillWithCapybaras(aviary, animalCount);
                    break;
                case Animals.Cat:
                    FillWithCats(aviary, animalCount);
                    break;
                case Animals.Zebra:
                    FillWithZebras(aviary, animalCount);
                    break;
                case Animals.SecretaryBird:
                    FillWithSecretaryBirds(aviary, animalCount);
                    break;
                case Animals.Platypus:
                    FillWithPlatypuses(aviary, animalCount);
                    break;
            }

            return aviary;
        }

        private static void FillWithCapybaras(Aviary aviary, int animalCount)
        {
            for (int i = 0; i < animalCount; i++)
            {
                aviary.TryAddAnimal(new Capybara(new CapybaraSound()));
            }
        }

        private static void FillWithCats(Aviary aviary, int animalCount)
        {
            for (int i = 0; i < animalCount; i++)
            {
                aviary.TryAddAnimal(new Cat(new CatSound()));
            }
        }

        private static void FillWithZebras(Aviary aviary, int animalCount)
        {
            for (int i = 0; i < animalCount; i++)
            {
                aviary.TryAddAnimal(new Zebra(new ZebraSound()));
            }
        }

        private static void FillWithSecretaryBirds(Aviary aviary, int animalCount)
        {
            for (int i = 0; i < animalCount; i++)
            {
                aviary.TryAddAnimal(new SecretaryBird(new SecretaryBirdSound()));
            }
        }

        private static void FillWithPlatypuses(Aviary aviary, int animalCount)
        {
            for (int i = 0; i < animalCount; i++)
            {
                aviary.TryAddAnimal(new Platypus(new PlatypusSound()));
            }
        }
    }
}