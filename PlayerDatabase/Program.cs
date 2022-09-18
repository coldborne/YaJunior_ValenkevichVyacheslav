using System;
using System.Collections.Generic;

namespace PlayerDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game fortnite = new Game();

            bool isGameOn = true;

            fortnite.AddNewPlayer();

            fortnite.Ban();

            fortnite = null;
            GC.Collect();
        }
    }

    public class Game
    {
        private Database database;

        public Game()
        {
            database = new Database();
        }

        public void AddNewPlayer()
        {
            Console.WriteLine("Имя игрока?");
            string nickname = Console.ReadLine();

            Player newPlayer = new Player(nickname);

            database.AddInPlayers(newPlayer);
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Id игрока?");
            string userInput = Console.ReadLine();
            int id = int.Parse(userInput);

            database.RemovePlayer(id);
        }

        public void Ban()
        {
            Console.WriteLine("Id игрока");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int id);

            Player player = database.GetPlayer(id);

            if (player != null)
            {
                bool isBanned = player.getIsBanned();

                database.MovePlayer(id, isBanned);
            }
        }
    }

    public class Player
    {
        private static List<int> allId = new List<int>();

        private int _id;
        private int _level;
        private string _nickname;
        private bool _isBanned;

        public Player(string nickname)
        {
            _id = allId.Count + 1;
            allId.Add(_id);
            _level = 1;
            _nickname = nickname;
            _isBanned = false;
        }

        public int getId()
        {
            return _id;
        }

        public bool getIsBanned()
        {
            return _isBanned;
        }
    }

    public class Database
    {
        private Dictionary<int, Player> players;
        private Dictionary<int, Player> bannedPlayers;

        public Database()
        {
            players = new Dictionary<int, Player>();
            bannedPlayers = new Dictionary<int, Player>();
        }

        public void AddInPlayers(Player player)
        {
            players.Add(player.getId(), player);
        }

        public bool TryGetPlayer(int id, out Player player, ref bool isBanned)
        {
            if (players.ContainsKey(id))
            {
                player = players[id];
                isBanned = player.getIsBanned();
                return true;
            }
            else if (bannedPlayers.ContainsKey(id))
            {
                player = players[id];
                isBanned = player.getIsBanned();
                return true;
            }
            else
            {
                player = null;
                isBanned = false;
                Console.WriteLine("Игрок под таким id не найден");
                return false;
            }
        }

        public Player GetPlayer(int id)
        {
            Player player = null;

            if (players.ContainsKey(id))
            {
                return players[id];
            }
            else if (bannedPlayers.ContainsKey(id))
            {
                return bannedPlayers[id];
            }
            else
            {
                Console.WriteLine("Игрок под таким id не найден");
                return null;
            }
        }

        public void RemovePlayer(int id)
        {
            if (players.ContainsKey(id))
            {
                players.Remove(id);
            }
            else if (bannedPlayers.ContainsKey(id))
            {
                bannedPlayers.Remove(id);
            }
            else
            {
                Console.WriteLine("Игрок под таким id не найден");
            }
        }

        public void MovePlayer(int id, bool isBanned)
        {
            if (isBanned)
            {
                players.Add(id, players[id]);
                bannedPlayers.Remove(id);
            }
            else
            {
                bannedPlayers.Add(id, players[id]);
                players.Remove(id);
            }
        }
    }
}
