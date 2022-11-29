namespace CardDeck
{
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
}