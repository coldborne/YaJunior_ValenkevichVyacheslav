using System;

namespace BookStorage
{
    public class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int ReleaseYear { get; private set; }

        public Book(string name, string author, int releaseYear)
        {
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название - {Name}, Автор - {Author}, Год выпуска - {ReleaseYear}");
        }
    }
}