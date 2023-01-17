using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck
{
    public class Croupier
    {
        private List<Card> _cards;

        public Croupier()
        {
            const int cardsCount = 54;
            _cards = new List<Card>(cardsCount);

            Init();

            ShuffleCards();
        }

        public (bool, Card) TryGiveCard()
        {
            if (_cards.Count > 0)
            {
                int cardNumber = 0;
                
                Card card = _cards[cardNumber];
                
                _cards.Remove(card);

                return (true, card);
            }

            Console.WriteLine("Карт в колоде нет");
            return (false, null);
        }

        private void ShuffleCards()
        {
            _cards = _cards.OrderBy(card => UserUtils.GetRandomInt(0, int.MaxValue)).ToList();
        }

        private void Init()
        {
            List<string> cardsValue = new List<string> 
                { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

            List<char> cardsSuit = new List<char> 
                { '♦', '♥', '♣', '♠'};
            
            foreach (char suit in cardsSuit)
            {
                foreach (string value in cardsValue)
                {
                    Card card = new Card(value, suit);

                    _cards.Add(card);
                }
            }
        }
    }
}