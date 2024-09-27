namespace TopServerPlayers
{
    public class Player
    {
        public Player(string name, int level, int strength)
        {
            Name = name;
            Level = level;
            Strength = strength;
        }

        public string Name { get; }
        public int Level { get; }
        public int Strength { get; }

        public override string ToString()
        {
            return $"Имя: {Name}, уровень: {Level}, показатель силы: {Strength}";
        }
    }
}