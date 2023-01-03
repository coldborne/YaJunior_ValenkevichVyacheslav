using System;

namespace PlayerDatabase
{
    public enum Commands : byte
    {
        First = 1,
        Second,
        Third,
        Fourth,
        Fifth
    }

    internal class Program
    {
        private static Database _database = new Database();

        private static void Main(string[] args)
        {
            bool isProgrammWorking = true;

            while (isProgrammWorking)
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine($"{(int)Commands.First} - Добавить игрока");
                Console.WriteLine($"{(int)Commands.Second} - Удалить игрока");
                Console.WriteLine($"{(int)Commands.Third} - Забанить игрока");
                Console.WriteLine($"{(int)Commands.Fourth} - Разбанить игрока");
                Console.WriteLine($"{(int)Commands.Fifth} - Выйти");

                int userChosenCommand = UserUtils.ReadCommand();

                switch (userChosenCommand)
                {
                    case (int)Commands.First:
                        AddNewPlayer();
                        break;
                    
                    case (int)Commands.Second:
                        DeletePlayer();
                        break;
                    
                    case (int)Commands.Third:
                        BanPlayer();
                        break;
                    
                    case (int)Commands.Fourth:
                        UnbanPlayer();
                        break;
                    
                    case (int)Commands.Fifth:
                        isProgrammWorking = false;
                        break;
                }
            }
        }

        private static void AddNewPlayer()
        {
            Console.WriteLine("Добавление игрока: ");

            Player newPlayer = CreatePlayer();

            _database.TryAddPlayer(newPlayer);
        }

        private static Player CreatePlayer()
        {
            string nickname = UserUtils.GenerateName();

            return new Player(nickname);
        }

        private static void DeletePlayer()
        {
            Console.WriteLine("Удаление игрока: ");

            bool wasPlayerReceived = _database.TryGetPlayer(out Player player);

            if (wasPlayerReceived)
            {
                _database.TryRemovePlayer(player);
            }
        }

        private static void BanPlayer()
        {
            Console.WriteLine("Бан игрока: ");

            bool wasPlayerReceived = _database.TryGetPlayer(out Player player);

            if (wasPlayerReceived)
            {
                _database.TryBan(player.Id);
            }
        }

        private static void UnbanPlayer()
        {
            Console.WriteLine("Разбан игрока: ");

            bool wasPlayerReceived = _database.TryGetPlayer(out Player player);

            if (wasPlayerReceived)
            {
                _database.TryUnban(player.Id);
            }
        }
    }
}