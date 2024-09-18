using System;

namespace Aquarium
{
    public enum Commands : byte
    {
        AddFish = 1,
        TakeOutFish,
        Skip,
        BrakeAquarium
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
                Console.WriteLine($"{(int)Commands.AddFish} - Добавить рыбку");
                Console.WriteLine($"{(int)Commands.TakeOutFish} - Вынуть рыбку");
                Console.WriteLine($"{(int)Commands.Skip} - Пропустить итерацию");
                Console.WriteLine($"{(int)Commands.BrakeAquarium} - Сломать аквариум");

                int commandsLength = Enum.GetNames(typeof(Commands)).Length;
                int userInput = UserUtils.ReadInt(commandsLength);

                aquarium.IncreaseFishAge();

                aquarium.CleanAquariumOfDeadFish();

                switch (userInput)
                {
                    case (int)Commands.AddFish:
                        AddFish(aquarium);
                        break;

                    case (int)Commands.TakeOutFish:
                        TakeOutRandomFish(aquarium);
                        break;

                    case (int)Commands.Skip:
                        break;

                    case (int)Commands.BrakeAquarium:
                        isAquariumWithoutDamage = false;
                        break;
                }
            }
        }

        private static void AddFish(Aquarium aquarium)
        {
            if (aquarium.TryAddFish())
            {
                Console.WriteLine("Успешно добавлена одна рыбка");
            }
            else
            {
                Console.WriteLine("Рыбка не добавлена");
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