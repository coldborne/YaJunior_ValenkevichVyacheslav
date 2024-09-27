namespace TopServerPlayers
{
    public class PLayerCreator
    {
        private Random _random;

        private List<string> _firstNames;

        public PLayerCreator()
        {
            _random = new Random();

            _firstNames = new List<string>
            {
                "Александр", "Мария", "Иван", "Елена", "Дмитрий",
                "Ольга", "Сергей", "Татьяна", "Андрей", "Наталья",
                "Михаил", "Светлана", "Николай", "Ирина", "Екатерина"
            };
        }

        public Player CreateRandomPlayer()
        {
            string firstName = _firstNames[_random.Next(_firstNames.Count)];

            int minLevel = 1;
            int maxLevel = 100;
            int level = _random.Next(minLevel, maxLevel + 1);

            int minStrength = 1;
            int maxStrength = 10;
            int strength = _random.Next(minStrength, maxStrength + 1);

            return new Player(firstName, level, strength);
        }

        public List<Player> CreateRandomPlayers(int count)
        {
            List<Player> patients = new List<Player>();

            for (int i = 0; i < count; i++)
            {
                patients.Add(CreateRandomPlayer());
            }

            return patients;
        }
    }
}