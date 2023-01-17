using System;

namespace BraveNewWorld
{
    public enum Symbols
    {
        Treasure = 'O',
        Wall = '#',
        PickedTreasure = 'X'
    }
    
    public class Game
    {
        public Game()
        {
            Console.CursorVisible = false;
        }

        public void Work()
        {
            Console.Clear();
            Console.WriteLine($"Добро пожаловать в нашу бродилку. Цель - собрать все сокровища (Помечены как {Symbols.Treasure})");
            Console.WriteLine("Движение стрелочками");

            bool isExit = false;
            const int treasureForWinCount = 5;

            (int X, int Y) userPosition = (1, 1);
            
            const int shiftPlusOne = 1;
            const int shiftMinusOne = -1;
            const int zeroShift = 0;
            
            char[] bag = new char[0];
            
            char[,] map =
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

            while (isExit == false)
            {
                Draw(userPosition, bag, map);

                isExit = CheckWin(bag, treasureForWinCount);
                
                if (isExit) continue;

                isExit = TakePlayerMovement(ref userPosition, zeroShift, shiftMinusOne, shiftPlusOne, ref bag, ref map);
            }
        }

        private bool TakePlayerMovement(ref (int X, int Y) userPosition, int zeroShift, int shiftMinusOne, int shiftPlusOne,
            ref char[] bag, ref char[,] map)
        {
            const ConsoleKey MoveUp = ConsoleKey.UpArrow;
            const ConsoleKey MoveDown = ConsoleKey.DownArrow;
            const ConsoleKey MoveRight = ConsoleKey.RightArrow;
            const ConsoleKey MoveLeft = ConsoleKey.LeftArrow;
            
            ConsoleKeyInfo userPressedButton = Console.ReadKey();

            switch (userPressedButton.Key)
            {
                case MoveUp:
                    userPosition = WorkWithPlayer(userPosition, zeroShift, shiftMinusOne, ref bag, ref map);
                    return false;

                case MoveDown:
                    userPosition = WorkWithPlayer(userPosition, zeroShift, shiftPlusOne, ref bag, ref map);
                    return false;

                case MoveLeft:
                    userPosition = WorkWithPlayer(userPosition, shiftMinusOne, zeroShift, ref bag, ref map);
                    return false;

                case MoveRight:
                    userPosition = WorkWithPlayer(userPosition, shiftPlusOne, zeroShift, ref bag, ref map);
                    return false;

                case ConsoleKey.Spacebar:
                    return true;
                
                default:
                    return false;
            }
        }

        private bool CheckWin(char[] bag, int treasureForWinCount)
        {
            if (bag.Length == treasureForWinCount)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nВы победили!");
                Console.ForegroundColor = default;

                return true;
            }

            return false;
        }

        private void Draw((int, int) userPosition, char[] bag, char[,] map)
        {
            const int offsetLeft = 0;
            const int offsetTop = 3;
        
            DrawMap(offsetLeft, offsetTop, map);

            DrawPlayer(userPosition, offsetLeft, offsetTop);

            DrawBag(bag);
        }

        private void DrawMap(int offsetLeft, int offsetTop, char[,] map)
        {
            Console.SetCursorPosition(offsetLeft, offsetTop);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    switch (map[i, j])
                    {
                        case (char)Symbols.Treasure:
                            DrawColoredSymbol(i, j, ConsoleColor.Yellow, map);
                            break;

                        case (char)Symbols.PickedTreasure:
                            DrawColoredSymbol(i, j, ConsoleColor.Blue, map);
                            break;

                        default:
                            DrawColoredSymbol(i, j, ConsoleColor.White, map);
                            break;
                    }
                }

                Console.WriteLine();
            }
        }

        private void DrawBag(char[] bag)
        {
            const int bagPositionX = 0;
            const int bagPositionY = 15;
        
            Console.SetCursorPosition(bagPositionX, bagPositionY);
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Сумка:");

            foreach (var treasure in bag)
            {
                Console.Write(treasure + " ");
            }

            Console.ForegroundColor = default;
        }

        private void DrawPlayer((int X, int Y) userPosition, int offsetLeft, int offsetTop)
        {
            Console.SetCursorPosition(userPosition.X + offsetLeft, userPosition.Y + offsetTop);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('@');
            Console.ForegroundColor = default;
        }

        private void DrawColoredSymbol(int left, int top, ConsoleColor color, char[,] map)
        {
            Console.ForegroundColor = color;
            Console.Write(map[left, top]);
            Console.ForegroundColor = default;
        }

        private (int, int) WorkWithPlayer((int X,int Y) userPosition, int left, int top, ref char[] bag, ref char[,] map)
        {
            int plannedPlayerPositionY = userPosition.Y + top;
            int plannedPlayerPositionX = userPosition.X + left;

            char plannedPositionOfThePlayer = map[plannedPlayerPositionY, plannedPlayerPositionX];

            if (plannedPositionOfThePlayer != (char)Symbols.Wall)
            {
                userPosition = ChangePlayerPosition(userPosition, left, top);
            }

            if (plannedPositionOfThePlayer == (char)Symbols.Treasure)
            {
                bag = TakeTreasure(plannedPlayerPositionX, plannedPlayerPositionY, bag, ref map);
            }

            return userPosition;
        }

        private (int, int) ChangePlayerPosition((int X,int Y) userPosition, int left, int top)
        {
            userPosition.Y += top;
            userPosition.X += left;

            return userPosition;
        }

        private char[] TakeTreasure(int plannedPlayerPositionX, int plannedPlayerPositionY, char[] bag, ref char[,] map)
        {
            bag = ExpandBag(bag);

            bag[bag.Length - 1] = (char)Symbols.Treasure;
            
            map[plannedPlayerPositionY, plannedPlayerPositionX] = (char)Symbols.PickedTreasure;

            return bag;
        }

        private char[] ExpandBag(char[] bag)
        {
            char[] tempBag = new char[bag.Length + 1];

            for (int i = 0; i < bag.Length; i++)
            {
                tempBag[i] = bag[i];
            }

            bag = tempBag;

            return bag;
        }
    }
}