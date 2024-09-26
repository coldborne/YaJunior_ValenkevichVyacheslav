namespace HospitalAnarchy
{
    public class PatientCreator
    {
        private Random _random;

        private List<string> _firstNames;
        private List<string> _lastNames;
        private List<string> _illnesses;

        public PatientCreator()
        {
            _random = new Random();

            _firstNames = new List<string>
            {
                "Александр", "Мария", "Иван", "Елена", "Дмитрий",
                "Ольга", "Сергей", "Татьяна", "Андрей", "Наталья",
                "Михаил", "Светлана", "Николай", "Ирина", "Екатерина"
            };

            _lastNames = new List<string>
            {
                "Иванов", "Петров", "Сидоров", "Кузнецов", "Соколов",
                "Попов", "Лебедев", "Козлов", "Новиков", "Морозов",
                "Волков", "Соловьёв", "Васильев", "Зайцев", "Павлов"
            };

            _illnesses = new List<string>
            {
                "Грипп", "Бронхит", "Пневмония", "Мигрень", "Астма",
                "Диабет", "Гипертония", "Ангина", "Аллергия", "Дерматит",
                "Гастрит", "Язва желудка", "Остеохондроз", "Радикулит", "Артериосклероз"
            };
        }

        public Patient CreateRandomPatient()
        {
            string fullName = GenerateRandomFullName();

            int minAge = 1;
            int maxAge = 100;
            int age = _random.Next(minAge, maxAge + 1);

            string illness = GenerateRandomIllness();

            return new Patient(fullName, age, illness);
        }

        public List<Patient> CreateRandomPatients(int count)
        {
            List<Patient> patients = new List<Patient>();

            for (int i = 0; i < count; i++)
            {
                patients.Add(CreateRandomPatient());
            }

            return patients;
        }

        private string GenerateRandomFullName()
        {
            string firstName = _firstNames[_random.Next(_firstNames.Count)];
            string lastName = _lastNames[_random.Next(_lastNames.Count)];
            return $"{firstName} {lastName}";
        }

        private string GenerateRandomIllness()
        {
            return _illnesses[_random.Next(_illnesses.Count)];
        }
    }
}