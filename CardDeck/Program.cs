using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck
{
    public enum CardValue { Ace = 1, two, three, four, five, six, seven, eight, nine, ten, Jack, Queen, King, Joker }
    public enum CardSuit { Diamonds, Hearts, Clubs, Spades }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            bool isGameStarted = true;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Лол Rider");
            }

            //while (isGameStarted)
            //{
            //    Console.WriteLine("Выберите нужное действие");
            //    Console.WriteLine("1 - Взять карту");
            //}
        }
    }
}
