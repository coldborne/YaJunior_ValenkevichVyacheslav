using System;

namespace WorkingWithProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player slava = new Player();
            slava.ShowInfo();

            int x = 10;
            int y = 12;
            (int, int) coordinates = (x, y);

            Player vlad = new Player(coordinates);
            vlad.ShowInfo();
        }
    }

    public class Player
    {
        private int _xCoordinate;
        private int _yCoordinate;

        public Player()
        {
            _xCoordinate = 0;
            _yCoordinate = 0;
        }

        public Player((int, int) coordinates)
        {
            _xCoordinate = coordinates.Item1;
            _yCoordinate = coordinates.Item2;
        }

        public string Name { get; private set; } = " ";

        public void ShowInfo()
        {
            if (Name == " ")
            {
                Console.WriteLine($"X - {_xCoordinate}, Y - {_yCoordinate}");
            }
            else
            {
                Console.WriteLine($"X - {_xCoordinate}, Y - {_yCoordinate}, Имя - {Name}");
            }
        }
    }
}
