namespace HospitalAnarchy
{
    public class Hospital
    {
        private List<Patient> _patients;
        private HospitalView _view;

        public Hospital(List<Patient> patients, HospitalView view)
        {
            _patients = patients;
            _view = view;
        }

        public void Work()
        {
            _view.ShowStartWindow();

            bool isExit = false;

            while (isExit == false)
            {
                _view.DisplayMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case HospitalCommands.SortByFullName:
                        SortByFullName();
                        break;

                    case HospitalCommands.SortByAge:
                        SortByAge();
                        break;

                    case HospitalCommands.FilterPatientsByIllness:
                        FilterPatientsByIllness();
                        break;

                    case HospitalCommands.Exit:
                        isExit = true;
                        break;

                    default:
                        _view.DisplayMessage("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }

        private void SortByFullName()
        {
            List<Patient> sortedByName = new List<Patient>(_patients);

            sortedByName.Sort((patient, otherPatient) =>
                String.Compare(patient.FullName, otherPatient.FullName, StringComparison.Ordinal));

            _view.DisplayPatients(sortedByName);
        }

        private void SortByAge()
        {
            List<Patient> sortedByAge = new List<Patient>(_patients);

            sortedByAge.Sort((patient, otherPatient) => patient.Age.CompareTo(otherPatient.Age));

            _view.DisplayPatients(sortedByAge);
        }

        private void FilterPatientsByIllness()
        {
            _view.DisplayIllnessPrompt();

            string illness = Console.ReadLine();

            List<Patient> filteredPatients = _patients.FindAll(patient =>
                patient.Illness.Equals(illness, StringComparison.OrdinalIgnoreCase));

            if (filteredPatients.Count > 0)
            {
                _view.DisplayPatients(filteredPatients);
            }
            else
            {
                _view.DisplayNoPatientsFound(illness);
            }
        }
    }
}