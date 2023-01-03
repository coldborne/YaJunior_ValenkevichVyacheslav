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
                Console.WriteLine($"{(int)Commands.First} - Добавить игрока");
                Console.WriteLine($"{(int)Commands.Second} - Удалить игрока");
                Console.WriteLine($"{(int)Commands.Third} - Забанить игрока");
                Console.WriteLine($"{(int)Commands.Fourth} - Разбанить игрока");
                Console.WriteLine($"{(int)Commands.Fifth} - Выйти");

                int userChosenCommand = UserUtils.ReadCommand();

                switch (userChosenCommand)
                {
                    case (int)Commands.First:
                        AddPlayer();
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
                        isProgramWorking = false;
                        break;
                }
            }
        }

        private void AddPlayer()
        {
            Player player = CreatePlayer();

            _players.Add(player);
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
            }
        }

        private void BanPlayer()
        {
            bool wasPlayerReceived = TryGetPlayer(out Player player);

            if (wasPlayerReceived)
            {
                if (player.IsBanned == false)
                {
                    player.Ban();

                    Console.WriteLine("Игрок забанен");
                }
                else
                {
                    Console.WriteLine("Игрок уже забанен");
                }
            }
        }

        private void UnbanPlayer()
        {
            bool wasPlayerReceived = TryGetPlayer(out Player player);

            if (wasPlayerReceived)
            {
                if (player.IsBanned)
                {
                    player.Unban();

                    Console.WriteLine("Игрок разбанен");
                }
                else
                {
                    Console.WriteLine("Игрок не находится в забаненном состоянии");
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

            for (int i = 0; i < startPlayersCount; i++)
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