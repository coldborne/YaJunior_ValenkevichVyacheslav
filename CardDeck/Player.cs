using System;
using System.Collections.Generic;

namespace CardDeck
{
    public class Player
    {
        private List<Card> _cardsInHand;
        private int _maxCardsInHandAmount = 6;

        public Player()
        {
            _cardsInHand = new List<Card>();
        }
        public void TakeCard(Card card)
        {
            if (_cardsInHand.Count < _maxCardsInHandAmount)
            {
                _cardsInHand.Add(card);
            }
            else
            {
                Console.WriteLine($"В руке максимальное количество карт (Равное - {_maxCardsInHandAmount}");
            }
        }
    }
}