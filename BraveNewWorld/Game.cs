using System;

namespace BraveNewWorld
{
    public class Game
    {
        private int _userPositionX = 1;
        private int _userPositionY = 1;

        private int _offsetLeft = 0;
        private int _offsetTop = 2;

        private char[] _bag = new char[0];

        private char[,] _map =
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'O', '#' },
            { '#', '#', '#', '#', 'O', '#', '#', '#', '#', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', ' ', '#', '#', ' ', '#', ' ', '#', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', '#', ' ', ' ', 'O', '#' },
            { '#', 'O', '#', ' ', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', 'O', '#', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        public Game()
        {
            Console.CursorVisible = false;
        }

        public void Work()
        {
            Console.WriteLine("Добро пожаловать в нашу бродилку. Цель - собрать все сокровища (Помечены как O)");
            Console.WriteLine("Движение стрелочками");

            bool isWork = true;

            while (isWork)
            {
                Draw();

                if (_bag.Length == 5)
                {
                    Console.WriteLine("\nВы победили!");

                    isWork = false;

                    continue;
                }

                ConsoleKeyInfo userPressedButton = Console.ReadKey();

                switch (userPressedButton.Key)
                {
                    case ConsoleKey.UpArrow:
                        WorkWithPlayerPosition(0, -1);
                        break;

                    case ConsoleKey.DownArrow:
                        WorkWithPlayerPosition(0, 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        WorkWithPlayerPosition(-1, 0);
                        break;

                    case ConsoleKey.RightArrow:
                        WorkWithPlayerPosition(1, 0);
                        break;

                    case ConsoleKey.Spacebar:
                        isWork = false;
                        break;
                }
            }
        }

        private void Draw()
        {
            Console.SetCursorPosition(_offsetLeft, _offsetTop);

            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    switch (_map[i, j])
                    {
                        case 'O':
                            DrawColoredSymbol(i, j, ConsoleColor.Yellow);
                            break;
                        
                        case 'X':
                            DrawColoredSymbol(i, j, ConsoleColor.Blue);
                            break;
                        
                        default:
                            DrawColoredSymbol(i, j, ConsoleColor.White);
                            break;
                    }
                }

                Console.WriteLine();
            }
            
            DrawPlayer();

            DrawBag();
        }

        private void DrawBag()
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Сумка:");

            foreach (var treasure in _bag)
            {
                Console.Write(treasure + " ");
            }
        }

        private void DrawPlayer()
        {
            Console.SetCursorPosition(_userPositionX + _offsetLeft, _userPositionY + _offsetTop);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('@');
            Console.ForegroundColor = default;
        }

        private void DrawColoredSymbol(int left, int top, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(_map[left, top]);
            Console.ForegroundColor = default;
        }

        private void WorkWithPlayerPosition(int left, int top)
        {
            int plannedPlayerPositionY = _userPositionY + top;
            int plannedPlayerPositionX = _userPositionX + left;

            char plannedPositionOfThePlayer = _map[plannedPlayerPositionY, plannedPlayerPositionX];

            if (plannedPositionOfThePlayer == ' ' || plannedPositionOfThePlayer == 'X')
            {
                ChangePlayerPosition(left, top);
            }

            if (plannedPositionOfThePlayer == 'O')
            {
                ChangePlayerPosition(left, top);
                
                TakeTreasure(plannedPlayerPositionX, plannedPlayerPositionY);
            }
        }

        private void ChangePlayerPosition(int left, int top)
        {
            _userPositionY += top;
            _userPositionX += left;
        }

        private void TakeTreasure(int plannedPlayerPositionX, int plannedPlayerPositionY)
        {
            _map[plannedPlayerPositionY, plannedPlayerPositionX] = 'X';

            ExpandBag();

            _bag[_bag.Length - 1] = 'O';
        }

        private void ExpandBag()
        {
            char[] tempBag = new char[_bag.Length + 1];

            for (int i = 0; i < _bag.Length; i++)
            {
                tempBag[i] = _bag[i];
            }

            _bag = tempBag;
        }
    }
}