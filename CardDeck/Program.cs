using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck
{
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

    public class Game
    {
        private CardDeck _cardDeck;

        public Game()
        {
            _cardDeck = new CardDeck();
        }

        public void ShuffleCardDeck()
        {
            _cardDeck.ShuffleCardDeck();
        }
    }

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

    public class Card
    {
        private string _value;
        private string _suit;

        public Card(string value, string suit)
        {
            _value = value;
            _suit = suit;
        }

        public override string ToString()
        {
            return $"{_suit}:{_value}";
        }
    }

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

    public enum CardValue { Ace = 1, two, three, four, five, six, seven, eight, nine, ten, Jack, Queen, King, Joker }
    public enum CardSuit { Diamonds, Hearts, Clubs, Spades }
}
