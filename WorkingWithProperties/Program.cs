using System;

namespace WorkingWithProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player slava = new Player();
            slava.ShowInfo();

            int xCoordinate = 10;
            int yCoordinate = 12;
            Coordinate coordinates = new Coordinate(xCoordinate, yCoordinate);

            Player suffocater = new Player(coordinates);
            suffocater.ShowInfo();
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

        public Player(Coordinate coordinates)
        {
            _xCoordinate = coordinates.X;
            _yCoordinate = coordinates.Y;
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
    
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
