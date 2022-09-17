using System;

namespace WorkingWithProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player slava = new Player();
            slava.ShowInfo();

            slava.Name = "Слава";
            slava.ShowInfo();

            int x = 10;
            int y = 12;
            (int, int) coordinates = (x, y);

            Player vlad = new Player(coordinates);
            vlad.ShowInfo();

            vlad.Name = "Влад";
            vlad.ShowInfo();
        }
    }

    public class Player
    {
        private int _x;
        private int _y;

        public string Name { get; set; } = " ";

        public Player()
        {
            _x = 0;
            _y = 0;
        }

        public Player((int, int) coordinates)
        {
            _x = coordinates.Item1;
            _y = coordinates.Item2;
        }

        public void ShowInfo()
        {
            if (Name == " ")
            {
                Console.WriteLine($"X - {_x}, Y - {_y}");
            }
            else
            {
                Console.WriteLine($"X - {_x}, Y - {_y}, Имя - {Name}");
            }
        }
    }
}
