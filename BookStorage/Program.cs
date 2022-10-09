using System;

namespace BookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StorageBook storageBook = new StorageBook();

            Console.WriteLine("Добро пожаловать в наше хранилище игр");
            Console.WriteLine("Выберите одно из возможных действий:");

            bool isStorageOpen = true;

            while (isStorageOpen)
            {
                Console.WriteLine(
                    "1 - добавить книгу, 2 - убрать книгу, 3 - показать все книги, " +
                    "4 - показать книги по конкретному параметру, 5 - Выход");

                int selectedCommand = UserUtils.ReadInt();

                switch (selectedCommand)
                {
                    case (int)Commands.First:
                        storageBook.AddBook();
                        break;
                    case (int)Commands.Second:
                        storageBook.TryRemoveBook();
                        break;
                    case (int)Commands.Third:
                        storageBook.ShowAllBooks();
                        break;
                    case (int)Commands.Fourth:
                        storageBook.ShowBooksByOption();
                        break;
                    case (int)Commands.Fifth:
                        isStorageOpen = false;
                        break;
                    default:
                        Console.WriteLine("Введена недопустимая команда");
                        break;
                }
            }
        }
    }
}