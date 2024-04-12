namespace PassengerTrainConfigurator
{
    public class Passenger
    {
        public Passenger(string surname, string name, string patronymic)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }

        public Passenger(string surname, string name)
        {
            Surname = surname;
            Name = name;
            Patronymic = string.Empty;
        }

        public string Surname { get; }
        public string Name { get; }
        public string Patronymic { get; }

        public override string ToString()
        {
            return Patronymic != string.Empty ? $"{Surname} {Name} {Patronymic}" : $"{Surname} {Name}";
        }
    }
}