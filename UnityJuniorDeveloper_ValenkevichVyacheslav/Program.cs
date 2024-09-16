using System;

namespace UnityJuniorDeveloper_ValenkevichVyacheslav
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите свой возраст");
            int.TryParse(Console.ReadLine(), out int age);

            Console.WriteLine("Введите своё имя");
            string name = Console.ReadLine().Replace(" ", "");

            Console.WriteLine("Введите своё место работы");
            string workPlace = Console.ReadLine().Replace(" ", "");

            Console.WriteLine("Введите своё любимое блюдо");
            string favoriteDish = Console.ReadLine().Replace(" ", "");

            Console.WriteLine($"Ваше имя: {name}.\nВаш возраст: {age}.\nВаше место работы: {workPlace}.\nВаше любимое блюдо: {favoriteDish}.");
        }
    }
}