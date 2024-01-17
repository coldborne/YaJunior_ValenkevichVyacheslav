using System;
using System.Collections.Generic;

namespace CardDeck
{
    public class Player
    {
        private List<Card> _cardsInHand;

        public Player()
        {
            _cardsInHand = new List<Card>();
            MaxCardsInHandAmount = 6;
        }
        
        public int MaxCardsInHandAmount { get; private set; }
        public int CardsInHandAmount => _cardsInHand.Count;

        public bool TryTakeCard(Card card)
        {
            if (CanTakeCard())
            {
                _cardsInHand.Add(card);
                
                return true;
            }

            return false;
        }

        public void ShowCardsInHand()
        {
            foreach (Card card in _cardsInHand)
            {
                Console.WriteLine(card.ToString());
            }
        }

        private bool CanTakeCard()
        {
            return _cardsInHand.Count <= MaxCardsInHandAmount;
        }
    }
}