using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace WorkingWithProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Drawer drawer = new Drawer();
            
            int xCoordinate = -10000;
            int yCoordinate = -10000;
            Coordinate coordinates = new Coordinate(xCoordinate, yCoordinate);

            Player suffocater = new Player(coordinates, "Слава");
            Player player = new Player();
            
            char playerSymbol = '@';
            char suffocaterSymbol = 'S';
            
            drawer.TryDrawPlayer(player, playerSymbol);
            drawer.TryDrawPlayer(suffocater, suffocaterSymbol);
            
            Console.ReadKey();
        }
    }

    public class Drawer
    {
        public void TryDrawPlayer(Player player, char playerSymbol)
        {
            if (canDraw(player.X, player.Y))
            {
                Console.SetCursorPosition(player.X, player.Y);
            
                Console.WriteLine(playerSymbol);
            }
        }

        private bool canDraw(int x, int y)
        {
            if (x >= 0 && x < Console.BufferWidth && y >= 0 && y < Console.BufferHeight)
            {
                return true;
            }

            return false;
        }
    }

    public class Player
    {
        private Coordinate _coordinates;

        public Player()
        {
            _coordinates = new Coordinate();
        }

        public Player(Coordinate coordinates, string name)
        {
            _coordinates = coordinates;
        }

        public int X => _coordinates.X;
        public int Y => _coordinates.Y;
    }
    
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate()
        {
            X = 1;
            Y = 1;
        }
        
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
