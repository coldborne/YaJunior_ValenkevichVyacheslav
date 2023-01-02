using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerDatabase
{
    public class Database
    {
        private List<Player> _players;

        public Database()
        {
            _players = new List<Player>();
            Init();
        }

        public bool TryAddPlayer(Player player)
        {
            if (player == null) return false;

            if (_players.Any(existingPlayer => existingPlayer.Id == player.Id))
            {
                Console.WriteLine("Игрок с таким id уже существует в БД");
                return false;
            }

            _players.Add(player);
            Console.WriteLine("Игрок добавлен в БД");

            return true;
        }

        public bool TryRemovePlayer(Player player)
        {
            if (player == null) return false;

            if (_players.Any(existingPlayer => existingPlayer.Id == player.Id))
            {
                _players.Remove(player);

                Console.WriteLine("Игрок удалён из БД");

                return true;
            }

            Console.WriteLine("Игрок не найден в БД");

            return false;
        }

        public bool TryBan(int id)
        {
            if (_players.Any(existingPlayer => existingPlayer.Id == id && existingPlayer.IsBanned == false))
            {
                _players.Find(player => player.Id == id).Ban();

                Console.WriteLine("Игрок забанен");

                return true;
            }

            Console.WriteLine("Игрок уже забанен или не существует в БД");

            return false;
        }

        public bool TryUnban(int id)
        {
            if (_players.Any(existingPlayer => existingPlayer.Id == id && existingPlayer.IsBanned))
            {
                _players.Find(player => player.Id == id).Unban();

                Console.WriteLine("Игрок разбанен");

                return true;
            }

            Console.WriteLine("Игрок не забанен или не существует в БД");

            return false;
        }

        public Player TryGetPlayer(int id)
        {
            foreach (Player existingPlayer in _players)
            {
                if (existingPlayer.Id == id)
                {
                    return existingPlayer;
                }
            }

            Console.WriteLine("Игрок с таким id не найден в БД");
            return null;
        }

        private void Init()
        {
            Console.WriteLine("Происходит инициализация новой БД");
            Console.WriteLine("Происходит добавление данных в БД");

            int startPlayersCount = 10;

            for (int i = 0; i < startPlayersCount; i++)
            {
                TryAddPlayer(new Player(UserUtils.GenerateName()));
            }
        }
    }
}