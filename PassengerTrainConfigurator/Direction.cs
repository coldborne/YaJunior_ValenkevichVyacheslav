namespace PassengerTrainConfigurator
{
    public class Direction
    {
        public Direction(string from, string to)
        {
            From = from;
            To = to;
        }

        public string From { get; }
        public string To { get; }

        public override string ToString()
        {
            return $"{From} : {To}";
        }
    }
}