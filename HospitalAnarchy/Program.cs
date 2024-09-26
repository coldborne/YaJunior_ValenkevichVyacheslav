namespace HospitalAnarchy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PatientCreator creator = new PatientCreator();
            int patientsCount = 20;
            List<Patient> patients = creator.CreateRandomPatients(patientsCount);

            HospitalView hospitalView = new HospitalView();

            Hospital hospital = new Hospital(patients, hospitalView);
            hospital.Work();
        }
    }
}