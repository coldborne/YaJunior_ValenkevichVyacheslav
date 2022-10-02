using System;
using System.Reflection;

namespace BookStorage
{
    internal class Program
    {
        public static int CurrentYear = DateTime.Now.Year;

        static void Main(string[] args)
        {
            StorageBook storageBook = new StorageBook();

            Console.WriteLine("Добро пожаловать в наше хранилище игр");
            Console.WriteLine("Выберите одно из возможных действий:");

            bool isStorageOpen = true;

            while (isStorageOpen)
            {
                Console.WriteLine("1 - добавить книгу, 2 - убрать книгу, 3 - показать все книги, 4 - показать книги по конкретному параметру, 5 - Выход");

                int selectedCommand = ReadInt();

                switch (selectedCommand)
                {
                    case 1:
                        storageBook.AddBook();
                        break;
                    case 2:
                        storageBook.TryRemoveBook();
                        break;
                    case 3:
                        storageBook.ShowAllBooks();
                        break;
                    case 4:
                        storageBook.ShowBooks();
                        break;
                    case 5:
                        isStorageOpen = false;
                        break;
                    default:
                        Console.WriteLine("Введена недопустимая команда");
                        break;
                }
            }
        }

        public static int ReadInt()
        {
            int userInputInt = 0;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                string userInput = Console.ReadLine();

                isInputRight = int.TryParse(userInput, out userInputInt);

                if (isInputRight == false)
                {
                    Console.WriteLine("Можно вводить только целые числа");
                }
                else
                {
                    if (userInputInt > 2022)
                    {
                        Console.WriteLine(
                            $"Текущий год - {Program.CurrentYear}, год выпуска не может быть больше текущего года");

                        isInputRight = false;
                    }
                }
            }

            return userInputInt;
        }
    }
}