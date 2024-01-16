using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck
{
    public class Croupier
    {
        private List<Card> _cards;

        public Croupier(int cardsCount)
        {
            _cards = new List<Card>(cardsCount);

            Init();

            ShuffleCards();
        }

        public int CardAmount => _cards.Count;

        public bool TryGiveCard(out Card card)
        {
            if (_cards.Count > 0)
            {
                int cardNumber = 0;
                
                card = _cards[cardNumber];
                
                _cards.Remove(card);

                return true;
            }
            
            card = null;
            
            return false;
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