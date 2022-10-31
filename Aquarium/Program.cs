using System;

namespace Aquarium
{
    public enum Commands : byte
    {
        First = 1,
        Second,
        Third,
        Fourth
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();

            Console.WriteLine("Введите начальное количество рыбок");
            int fishCount = UserUtils.ReadFishCount(aquarium);

            for (int i = 0; i < fishCount; i++)
            {
                aquarium.TryAddFish();
            }

            bool isAquariumWithoutDamage = true;

            while (isAquariumWithoutDamage)
            {
                aquarium.ShowAllFishes();

                Console.WriteLine("Выберите действие");
                Console.WriteLine($"{(int)Commands.First} - Добавить рыбку");
                Console.WriteLine($"{(int)Commands.Second} - Вынуть рыбку");
                Console.WriteLine($"{(int)Commands.Third} - Пропустить итерацию");
                Console.WriteLine($"{(int)Commands.Fourth} - Сломать аквариум");
                
                int userInput = UserUtils.ReadCommand();
                
                aquarium.ReduceFishesAge();

                aquarium.CleanAquariumOfDeadFish();

                switch (userInput)
                {
                    case (int)Commands.First:
                        aquarium.TryAddFish();
                        break;
                    case (int)Commands.Second:
                        aquarium.PullOutRandomFish();
                        break;
                    case (int)Commands.Third:
                        break;
                    case (int)Commands.Fourth:
                        isAquariumWithoutDamage = false;
                        break;
                }
            }
        }
    }
}