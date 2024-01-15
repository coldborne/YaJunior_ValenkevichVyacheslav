using System;
using System.Collections.Generic;

namespace CardDeck
{
    public class Player
    {
        private List<Card> _cardsInHand;
        
        public int MaxCardsInHandAmount { get; private set; }

        public Player()
        {
            _cardsInHand = new List<Card>();
            MaxCardsInHandAmount = 6;
        }

        public bool TryTakeCard(Card card)
        {
            if (_cardsInHand.Count == MaxCardsInHandAmount)
            {
                return false;
            }
            
            _cardsInHand.Add(card);

            return true;
        }

        public void ShowCardsInHand()
        {
            foreach (Card card in _cardsInHand)
            {
                Console.WriteLine(card.ToString());
            }
        }

        public int GetCardsInHandAmount()
        {
            return _cardsInHand.Count;
        }
    }
}