using System;
using System.Collections.Generic;

namespace PlayerDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game fortnite = new Game();

            fortnite.AddNewPlayer();

            fortnite.BanPlayer();

            fortnite.DeletePlayer();

            fortnite = null;
            GC.Collect();

            Console.WriteLine("Игра закрыта");
        }
    }

    public class Game
    {
        private Database _database;

        public Game()
        {
            _database = new Database();
        }

        public void AddNewPlayer()
        {
            Console.WriteLine("Добавление игрока: ");

            Player newPlayer = CreatePlayer();

            _database.AddInPlayers(newPlayer);
        }

        public Player CreatePlayer()
        {
            Console.WriteLine("Имя игрока?");
            string nickname = Console.ReadLine();

            Player newPlayer = new Player(nickname);

            return newPlayer;
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Удаление игрока: ");

            Console.WriteLine("Id игрока?");
            GetId(out int id);

            _database.TryRemovePlayer(id, out bool wasRemoved);
        }

        public void BanPlayer()
        {
            Console.WriteLine("Бан игрока: ");
            Console.WriteLine("Id игрока");
            GetId(out int id);

            Player player = _database.TryGetPlayer(id);

            if (player != null)
            {
                _database.ChangeIsBannedOfPlayer(id);
            }
        }

        private void GetId(out int id)
        {
            id = 0;
            bool isNumber = false;

            while (isNumber == false)
            {
                string userInput = Console.ReadLine();

                isNumber = int.TryParse(userInput, out id);

                if (isNumber == false)
                {
                    Console.WriteLine("Введенно нецелое число, попробуйте ещё раз");
                }
            }
        }
    }

    public class Player
    {
        private static List<int> allId = new List<int>();

        private int _level;
        private string _nickname;

        public int Id { get; private set; }
        public bool IsBanned { get; private set; }
        
        public Player(string nickname)
        {
            Id = allId.Count + 1;
            allId.Add(Id);
            _level = 1;
            _nickname = nickname;
        }

        public void ChangeIsBanned()
        {
            IsBanned = !IsBanned;
        }
    }

    public class Database
    {
        private Dictionary<int, Player> _players;

        public Database()
        {
            _players = new Dictionary<int, Player>();
        }

        public void AddInPlayers(Player player)
        {
            _players.Add(player.Id, player);
            Console.WriteLine("Игрок добавлен");
        }

        public Player TryGetPlayer(int id)
        {
            Player player = null;

            if (_players.ContainsKey(id))
            {
                player = GetPlayer(id);
            }
            else
            {
                Console.WriteLine("Игрок под таким id не найден (Возможно, уже удалён, на данный момент нет базы данных удалённых игроков)");
            }

            return player;
        }

        private Player GetPlayer(int id)
        {
            return _players[id];
        }

        public void TryRemovePlayer(int id, out bool wasRemoved)
        {
            Player player = TryGetPlayer(id);

            if (player != null)
            {
                _players.Remove(id);

                wasRemoved = true;
                Console.WriteLine("Игрок удалён");
            }
            else
            {
                wasRemoved = false;
            }
        }

        public void ChangeIsBannedOfPlayer(int id)
        {
            if (_players[id].IsBanned == false)
            {
                _players[id].ChangeIsBanned();
                Console.WriteLine("Игрок забанен");
            }
            else
            {
                Console.WriteLine("Игрок уже забанен");
            }
        }
    }
}
