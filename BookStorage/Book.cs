using System;

namespace BookStorage
{
    public class Book
    {
        public string Name { get; }
        public string Author { get; }
        public int ReleaseYear { get; }

        public Book(string name, string author, int releaseYear)
        {
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public void ShowInfo()
        {
            ConsoleColorizer.WriteLineColored($"Название - {Name}, Автор - {Author}, Год выпуска - {ReleaseYear}",
                ConsoleColor.Yellow);
        }

        public Book Clone()
        {
            return new Book(Name, Author, ReleaseYear);
        }

        public override bool Equals(object other)
        {
            if (other is Book different)
            {
                return Name == different.Name && Author == different.Author && ReleaseYear == different.ReleaseYear;
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 23 + (Author != null ? Author.GetHashCode() : 0);
                hash = hash * 23 + ReleaseYear.GetHashCode();

                return hash;
            }
        }
    }
}