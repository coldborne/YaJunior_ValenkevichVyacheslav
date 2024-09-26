namespace HospitalAnarchy
{
    public class Patient
    {
        public Patient(string fullName, int age, string illness)
        {
            FullName = fullName;
            Age = age;
            Illness = illness;
        }

        public string FullName { get; }
        public int Age { get; }
        public string Illness { get; }

        public override string ToString()
        {
            return $"ФИО: {FullName}, возраст: {Age}, заболевание: {Illness}";
        }
    }
}