using System;
using System.Collections.Generic;

namespace CardDeck
{
    public class Player
    {
        public List<Card> CardsInHand { get; }
        public int MaxCardsInHandAmount { get; private set; }

        public Player()
        {
            CardsInHand = new List<Card>();
            MaxCardsInHandAmount = 6;
        }

        public void TakeCard(Card card)
        {
            if (CardsInHand.Count == MaxCardsInHandAmount)
            {
                Console.WriteLine("У пользователя максимальное количество карт в руке");
                return;
            }

            if (card != null)
            {
                CardsInHand.Add(card);
            }
        }

        public void ShowCardInHand()
        {
            foreach (Card card in CardsInHand)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}