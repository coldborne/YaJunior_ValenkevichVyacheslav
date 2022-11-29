using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck
{
    public class CardDeck
    {
        public List<Card> Cards { get; private set; }

        public List<Card> Deck { get; private set; }

        public CardDeck()
        {
            Cards = new List<Card>(54);

            AddCards();

            ShuffleCardDeck();
        }
        
        private void AddCards()
        {
            foreach (var suit in Enum.GetNames(typeof(CardSuit)))
            {
                foreach (var value in Enum.GetNames(typeof(CardValue)))
                {
                    Card card = new Card(value, suit);
                    Cards.Add(card);
                    //Console.WriteLine(card.ToString());
                }
            }
        }

        public void ShuffleCardDeck()
        {
            Deck = Cards;

            Random random = new Random();
            Deck = Deck.OrderBy(card => random.Next()).ToList();
        }
    }
}