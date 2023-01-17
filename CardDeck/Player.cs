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

        public void TryTakeCard((bool IsCardExist, Card Card) cardInfo)
        {
            if (_cardsInHand.Count == MaxCardsInHandAmount)
            {
                Console.WriteLine("У пользователя максимальное количество карт в руке");
                return;
            }

            if (cardInfo.IsCardExist)
            {
                _cardsInHand.Add(cardInfo.Card);
            }
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