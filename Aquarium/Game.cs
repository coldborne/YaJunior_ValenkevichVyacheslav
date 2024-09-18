using System;

namespace Aquarium
{
    public class Game
    {
        private Aquarium _aquarium;

        public Game(Aquarium aquarium)
        {
            _aquarium = aquarium;
        }

        public void Play()
        {
            bool isAquariumWithoutDamage = true;

            while (isAquariumWithoutDamage)
            {
                _aquarium.ShowAllFish();

                Console.WriteLine("Выберите действие");
                Console.WriteLine($"{(int)Commands.AddFish} - Добавить рыбку");
                Console.WriteLine($"{(int)Commands.TakeOutFish} - Вынуть рыбку");
                Console.WriteLine($"{(int)Commands.Skip} - Пропустить итерацию");
                Console.WriteLine($"{(int)Commands.BrakeAquarium} - Сломать аквариум");

                int commandsLength = Enum.GetNames(typeof(Commands)).Length;
                int userInput = UserUtils.ReadInt(commandsLength);

                _aquarium.IncreaseFishAge();

                _aquarium.CleanAquariumOfDeadFish();

                switch (userInput)
                {
                    case (int)Commands.AddFish:
                        AddFish(_aquarium);
                        break;

                    case (int)Commands.TakeOutFish:
                        TakeOutRandomFish(_aquarium);
                        break;

                    case (int)Commands.Skip:
                        break;

                    case (int)Commands.BrakeAquarium:
                        isAquariumWithoutDamage = false;
                        break;
                }
            }
        }

        private void AddFish(Aquarium aquarium)
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

        private void TakeOutRandomFish(Aquarium aquarium)
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