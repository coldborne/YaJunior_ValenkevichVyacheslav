using System;

namespace BraveNewWorld
{
    public enum Symbols
    {
        Treasure = 'O',
        Wall = '#',
        PickedTreasure = 'X',
        User = '@',
    }

    public class Game
    {
        public Game()
        {
            Console.CursorVisible = false;
        }

        public void Work()
        {
            const int TreasureForWinCount = 5;
            const int ShiftPlusOne = 1;
            const int ShiftMinusOne = -1;
            const int ZeroShift = 0;

            Console.Clear();

            Console.WriteLine(
                $"Добро пожаловать в нашу бродилку. Цель - собрать все сокровища (Помечены как {(char)Symbols.Treasure})");
            Console.WriteLine("Движение стрелочками");

            bool isExit = false;

            (int userPositionX, int userPositionY) userPosition = (1, 1);

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

                isExit = HaveCollectedAllTreasures(bag, TreasureForWinCount);

                if (isExit)
                {
                    continue;
                }

                ConsoleKeyInfo userPressedButton = Console.ReadKey();

                if (userPressedButton.Key == ConsoleKey.Spacebar)
                {
                    isExit = true;
                    continue;
                }

                MoveUser(ref userPosition, ZeroShift, ShiftMinusOne, ShiftPlusOne, map, userPressedButton.Key);

                char symbolOnUserPosition = map[userPosition.userPositionY, userPosition.userPositionX];

                if (symbolOnUserPosition == (char)Symbols.Treasure)
                {
                    bag = TakeTreasure(bag);

                    map[userPosition.userPositionY, userPosition.userPositionX] = (char)Symbols.PickedTreasure;
                }
            }
        }

        private void MoveUser(ref (int userPositionX, int userPositionY) userPosition, int zeroShift, int shiftMinusOne,
            int shiftPlusOne,
            char[,] map, ConsoleKey userPressedButton)
        {
            (int leftShift, int topShift) direction =
                DetermineDirectionOfMovement(userPressedButton, zeroShift, shiftMinusOne, shiftPlusOne);

            if (CanMove(ref userPosition, direction.leftShift, direction.topShift, map))
            {
                userPosition = Move(userPosition, direction.leftShift, direction.topShift);
            }
        }

        private (int leftShift, int topShift) DetermineDirectionOfMovement(ConsoleKey userPressedButton, int zeroShift,
            int shiftMinusOne,
            int shiftPlusOne)
        {
            (int leftShift, int topShift) direction = (0, 0);

            const ConsoleKey MoveUpKey = ConsoleKey.UpArrow;
            const ConsoleKey MoveDownKey = ConsoleKey.DownArrow;
            const ConsoleKey MoveRightKey = ConsoleKey.RightArrow;
            const ConsoleKey MoveLeftKey = ConsoleKey.LeftArrow;

            switch (userPressedButton)
            {
                case MoveUpKey:
                    direction = (zeroShift, shiftMinusOne);
                    break;

                case MoveDownKey:
                    direction = (zeroShift, shiftPlusOne);
                    break;

                case MoveLeftKey:
                    direction = (shiftMinusOne, zeroShift);
                    break;

                case MoveRightKey:
                    direction = (shiftPlusOne, zeroShift);
                    break;
            }

            return direction;
        }

        private bool CanMove(
            ref (int userPositionX, int userPositionY) userPosition, int left, int top, char[,] map)
        {
            int plannedPlayerPositionY = userPosition.userPositionY + top;
            int plannedPlayerPositionX = userPosition.userPositionX + left;

            char plannedPositionOfThePlayer = map[plannedPlayerPositionY, plannedPlayerPositionX];

            if (plannedPositionOfThePlayer != (char)Symbols.Wall)
            {
                return true;
            }

            return false;
        }

        private (int userPositionX, int userPositionY) Move((int userPositionX, int userPositionY) userPosition,
            int left, int top)
        {
            userPosition.userPositionY += top;
            userPosition.userPositionX += left;

            return userPosition;
        }

        private bool HaveCollectedAllTreasures(char[] bag, int treasureForWinCount)
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
            const int OffsetLeft = 0;
            const int OffsetTop = 5;

            const int BagPositionX = 0;
            const int BagPositionY = 17;

            DrawMap(OffsetLeft, OffsetTop, map);

            DrawPlayer(userPosition, OffsetLeft, OffsetTop);

            DrawBag(bag, BagPositionX, BagPositionY);
        }

        private void DrawMap(int offsetLeft, int offsetTop, char[,] map)
        {
            Console.SetCursorPosition(offsetLeft, offsetTop);

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
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

        private void DrawBag(char[] bag, int bagPositionX, int bagPositionY)
        {
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
            Console.Write((char)Symbols.User);
            Console.ForegroundColor = default;
        }

        private void DrawColoredSymbol(int left, int top, ConsoleColor color, char[,] map)
        {
            Console.ForegroundColor = color;
            Console.Write(map[left, top]);
            Console.ForegroundColor = default;
        }

        private char[] TakeTreasure(char[] bag)
        {
            bag = ExpandBag(bag);

            bag[bag.Length - 1] = (char)Symbols.Treasure;

            return bag;
        }

        private char[] ExpandBag(char[] bag)
        {
            char[] tempBag = new char[bag.Length + 1];

            for(int i = 0; i < bag.Length; i++)
            {
                tempBag[i] = bag[i];
            }

            bag = tempBag;

            return bag;
        }
    }
}