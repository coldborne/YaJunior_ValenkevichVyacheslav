namespace CardDeck
{
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
}