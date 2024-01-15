using System;
using System.Collections.Generic;

namespace PlayerDatabase
{
    public class Database
    {
        private List<Player> _players;

        public Database()
        {
            Init();
        }

        public void Work()
        {
            bool isProgramWorking = true;

            while (isProgramWorking)
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine($"{(int)Command.AddPlayer} - Добавить игрока");
                Console.WriteLine($"{(int)Command.DeletePlayer} - Удалить игрока");
                Console.WriteLine($"{(int)Command.BanPlayer} - Забанить игрока");
                Console.WriteLine($"{(int)Command.UnbanPlayer} - Разбанить игрока");
                Console.WriteLine($"{(int)Command.Exit} - Выйти");

                int userChosenCommand = UserUtils.ReadCommand();

                switch (userChosenCommand)
                {
                    case (int)Command.AddPlayer:
                        AddPlayer();
                        break;

                    case (int)Command.DeletePlayer:
                        DeletePlayer();
                        break;

                    case (int)Command.BanPlayer:
                        BanPlayer();
                        break;

                    case (int)Command.UnbanPlayer:
                        UnbanPlayer();
                        break;

                    case (int)Command.Exit:
                        isProgramWorking = false;
                        break;
                }
            }
        }

        private void AddPlayer()
        {
            Player player = CreatePlayer();

            _players.Add(player);

            Console.WriteLine($"Игрок - {player.Nickname} успешно добавлен в БД");
        }

        private Player CreatePlayer()
        {
            Console.WriteLine("Введите имя игрока: ");
            string name = Console.ReadLine();

            return new Player(name);
        }

        private void DeletePlayer()
        {
            Console.WriteLine("Удаление игрока: ");

            bool wasPlayerReceived = TryGetPlayer(out Player player);

            if (wasPlayerReceived)
            {
                _players.Remove(player);

                Console.WriteLine($"Игрок - {player.Nickname} успешно удалён из БД");
            }
        }

        private void BanPlayer()
        {
            bool wasPlayerReceived = TryGetPlayer(out Player player);

            if (wasPlayerReceived)
            {
                Console.Write($"Игрок - {player.Nickname} ");

                if (player.IsBanned == false)
                {
                    player.Ban();

                    Console.WriteLine($"забанен");
                }
                else
                {
                    Console.WriteLine($"уже забанен");
                }
            }
        }

        private void UnbanPlayer()
        {
            bool wasPlayerReceived = TryGetPlayer(out Player player);

            if (wasPlayerReceived)
            {
                Console.Write($"Игрок - {player.Nickname} ");

                if (player.IsBanned)
                {
                    player.Unban();

                    Console.WriteLine("разбанен");
                }
                else
                {
                    Console.WriteLine("не находится в забаненном состоянии");
                }
            }
        }

        private bool TryGetPlayer(out Player player)
        {
            Console.WriteLine("Введите Id игрока");
            int id = UserUtils.ReadInt();

            Console.WriteLine("Происходит поиск игрока: ");

            foreach (Player existingPlayer in _players)
            {
                if (existingPlayer.Id == id)
                {
                    player = existingPlayer;

                    Console.WriteLine("Игрок найден!");
                    return true;
                }
            }

            Console.WriteLine("Игрок с таким id не найден в БД");
            player = null;

            return false;
        }

        private void Init()
        {
            Console.WriteLine("Происходит инициализация новой БД");
            _players = new List<Player>();

            Console.WriteLine("Происходит добавление данных в БД");
            const int startPlayersCount = 10;

            for(int i = 0; i < startPlayersCount; i++)
            {
                _players.Add(GeneratePlayer());
            }
        }

        private Player GeneratePlayer()
        {
            return new Player(UserUtils.GenerateName());
        }
    }
}