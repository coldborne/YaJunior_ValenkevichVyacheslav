using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStorage
{
    public class StorageBook
    {
        private List<Book> _books;

        public StorageBook()
        {
            _books = new List<Book>();
        }

        public void ShowAllBooks()
        {
            if (_books.Count > 0)
            {
                foreach (Book book in _books)
                {
                    book.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("В хранилище нет книг");
            }
        }

        public void AddBook()
        {
            Book book = CreateBook();

            if (book != null)
            {
                _books.Add(book);
            }
        }

        public void RemoveBook()
        {
            if (_books.Count > 0)
            {
                Console.WriteLine("Введите название книги");
                string name = ReadString();
                
                Console.WriteLine("Введите автора книги");
                string author = ReadString();
                
                Console.WriteLine("Введите год выпуска книги");
                int releaseYear = Program.ReadInt();

                List<Book> _booksCopy = new List<Book>(_books);
                
                foreach (var book in _booksCopy.Where(book =>
                             book.Name == name && book.Author == author && book.ReleaseYear == releaseYear))
                {
                    _books.Remove(book);
                }
            }
            else
            {
                Console.WriteLine("В хранилище нет книг");
            }
        }

        private Book CreateBook()
        {
            Console.WriteLine("Введите название книги");
            string name = ReadString();

            Console.WriteLine("Введите автора книги");
            string author = ReadString();

            Console.WriteLine("Введите год выпуска книги");
            int releaseYear = Program.ReadInt();

            foreach (var book in _books.Where(book =>
                         book.Name == name && book.Author == author && book.ReleaseYear == releaseYear))
            {
                Console.WriteLine("Такая книга уже существует");
                return null;
            }
            
            return new Book(name, author, releaseYear);
        }

        public void ShowBooksByOption()
        {
            if (_books.Count > 0)
            {
                ChooseOption(out int releaseYear, out string name, out string author);
            
                foreach (var book in _books.Where(book =>
                             book.Name == name || book.Author == author || book.ReleaseYear == releaseYear))
                {
                    book.ShowInfo();
                } 
            }
            else
            {
                Console.WriteLine("В хранилище нет книг");
            }
        }

        private void ChooseOption(out int releaseYear, out string name, out string author)
        {
            releaseYear = -100;
            name = null;
            author = null;
            
            bool isCommandRight = false;
            
            Console.WriteLine("Выберите один из возможных параметров:");
            Console.WriteLine("1 - Название, 2 - Автор, 3 - Год издания");

            while (isCommandRight == false)
            {
                int selectedCommand = Program.ReadInt();

                switch (selectedCommand)
                {
                    case 1:
                        Console.WriteLine("Введите название");
                        name = ReadString();
                        isCommandRight = true;
                        break;
                    case 2:
                        Console.WriteLine("Введите автора");
                        author = ReadString();
                        isCommandRight = true;
                        break;
                    case 3:
                        Console.WriteLine("Введите год издания");
                        releaseYear = Program.ReadInt();
                        isCommandRight = true;
                        break;
                    default:
                        Console.WriteLine("Недопустимая команда");
                        break;
                }
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