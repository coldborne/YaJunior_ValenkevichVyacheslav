using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck
{
    public class Deck
    {
        private enum CardValue
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        private enum CardSuit
        {
            Diamonds,
            Hearts,
            Clubs,
            Spades
        }

        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new List<Card>(54);

            Init();

            Shuffle();
        }

        public void DeleteCard(Card card)
        {
            if (Cards.Contains(card))
            {
                Cards.Remove(card);
            }
        }

        private void Shuffle()
        {
            Cards = Cards.OrderBy(card => UserUtils.GetRandomInt(0, int.MaxValue)).ToList();
        }

        private void Init()
        {
            foreach (var suit in Enum.GetNames(typeof(CardSuit)))
            {
                foreach (var value in Enum.GetNames(typeof(CardValue)))
                {
                    Card card = new Card(value, suit);

                    Cards.Add(card);
                }
            }
        }
    }
}