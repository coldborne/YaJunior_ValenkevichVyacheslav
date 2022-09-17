using System;

namespace WorkingWithClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player slava = new Player();

            int age = 22;
            string name = "Влад";
            string description = "Ментор, будущий миллиардер";

            Player vlad = new Player(age, name, description);

            slava.ShowInfo();
            vlad.ShowInfo();
        }
    }

    public class Player
    {
        private int _age;
        private string _name;
        private string _description;

        public Player()
        {
            _age = 23;
            _name = "Слава";
            _description = "Будущий программист C#";
        }

        public Player(int age, string name, string description)
        {
            _age = age;
            _name = name;
            _description = description;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Возраст - {_age}, Имя - {_name}, - Описание - {_description}");
        }
    }
}
