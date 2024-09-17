using System;

namespace Aquarium
{
    public enum Commands : byte
    {
        AddFishCommand = 1,
        TakeOutFishCommand,
        SkipCommand,
        BrakeAquariumCommand
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();

            aquarium.Fill();

            bool isAquariumWithoutDamage = true;

            while (isAquariumWithoutDamage)
            {
                aquarium.ShowAllFish();

                Console.WriteLine("Выберите действие");
                Console.WriteLine($"{(int)Commands.AddFishCommand} - Добавить рыбку");
                Console.WriteLine($"{(int)Commands.TakeOutFishCommand} - Вынуть рыбку");
                Console.WriteLine($"{(int)Commands.SkipCommand} - Пропустить итерацию");
                Console.WriteLine($"{(int)Commands.BrakeAquariumCommand} - Сломать аквариум");

                int userInput = UserUtils.ReadCommand();

                aquarium.ReduceFishAge();

                aquarium.CleanAquariumOfDeadFish();

                switch (userInput)
                {
                    case (int)Commands.AddFishCommand:
                        aquarium.TryAddFish();
                        break;

                    case (int)Commands.TakeOutFishCommand:
                        TakeOutRandomFish(aquarium);
                        break;

                    case (int)Commands.SkipCommand:
                        break;

                    case (int)Commands.BrakeAquariumCommand:
                        isAquariumWithoutDamage = false;
                        break;
                }
            }
        }

        private static void TakeOutRandomFish(Aquarium aquarium)
        {
            if (aquarium.TryTakeOutRandomFish())
            {
                Console.WriteLine("Успешно вытащена одна рыбка");
            }
            else
            {
                Console.WriteLine("Аквариум уже пуст");
            }
        }
    }
}