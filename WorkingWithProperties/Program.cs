using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace WorkingWithProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Drawer drawer = new Drawer();
            
            int xCoordinate = 10;
            int yCoordinate = 12;
            Coordinate coordinates = new Coordinate(xCoordinate, yCoordinate);

            char suffocaterSkin = 'S';
            
            Player suffocater = new Player(coordinates, suffocaterSkin);
            Player player = new Player();
            
            drawer.TryDrawPlayer(player);
            drawer.TryDrawPlayer(suffocater);
        }
    }

    public class Drawer
    {
        public void TryDrawPlayer(Player player)
        {
            if (CanDraw(player.XCoordinate, player.YCoordinate))
            {
                Console.SetCursorPosition(player.XCoordinate, player.YCoordinate);
            
                Console.WriteLine(player.Skin);
            }
        }

        private bool CanDraw(int x, int y)
        {
            return x >= 0 && x < Console.BufferWidth && y >= 0 && y < Console.BufferHeight;
        }
    }

    public class Player
    {
        private Coordinate _coordinates;

        public Player()
        {
            _coordinates = new Coordinate();
            Skin = 'G';
        }

        public Player(Coordinate coordinates, char skin)
        {
            _coordinates = coordinates;
            Skin = skin;
        }

        public char Skin { get; private set; }
        public int XCoordinate => _coordinates.X;
        public int YCoordinate => _coordinates.Y;
    }
    
    public class Coordinate
    {
        public Coordinate(int x = 1, int y = 1)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
