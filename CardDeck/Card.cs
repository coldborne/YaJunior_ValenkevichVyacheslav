namespace CardDeck
{
    public class Card
    {
        private string _value;
        private char _suit;

        public Card(string value, char suit)
        {
            _value = value;
            _suit = suit;
        }

        public override string ToString()
        {
            return $"{_suit}:{_value}";
        }
    }
}