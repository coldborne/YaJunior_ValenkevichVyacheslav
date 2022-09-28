using System;
using System.Collections.Generic;
using System.Reflection;

namespace BookStorage
{
    public class StorageBook
    {
        public List<Book> Books { get; private set; }

        public StorageBook()
        {
            Books = new List<Book>();
        }

        public void ShowAllBooks()
        {
            foreach (Book book in Books)
            {
                book.ShowInfo();
            }
        }

        public void AddBook()
        {
            Book book = CreateBook();

            Books.Add(book);
        }

        public bool TryRemoveBook()
        {
            return true;
        }

        private Book CreateBook()
        {
            Console.WriteLine("Введите название книги");
            string bookName = ReadString();

            Console.WriteLine("Введите автора книги");
            string bookAuthor = ReadString();

            Console.WriteLine("Введите год выпуска книги");
            int bookReleaseYear = Program.ReadInt();

            return new Book(bookName, bookAuthor, bookReleaseYear);
        }

        public void ShowBook()
        {
            Console.WriteLine("Выберите один из возможных параметров:");

            // Type bookType = typeof(Book);
            // PropertyInfo[] bookFields = bookType.GetProperties();
            //
            // for (int i = 0; i < bookFields.Length; i++)
            // {
            //     Console.Write($"{i + 1} - {bookFields[i].Name} ");
            // }

            Console.WriteLine("1 - Название, 2 - Автор, 3 - Год издания");
            
            int selectedCommand = Program.ReadInt();

            switch (selectedCommand)
            {
                case 1:
                    var userInput = ReadString();
                    break;
                case 2:
                    var userInput = Program.ReadInt();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Введена недопустимая команда");
                    break;
            }
        }

        private string ReadString()
        {
            string userInput = null;
            bool isInputRight = false;

            while (isInputRight == false)
            {
                userInput = Console.ReadLine();
                
                if (userInput == null || userInput.Trim() == "")
                {
                    Console.WriteLine("Строка должна содержать хотя бы один символ неравный пробелу");
                }
                else
                {
                    isInputRight = true;
                }
            }

            return userInput;
        }
    }
}