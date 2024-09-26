namespace HospitalAnarchy
{
    public class HospitalView
    {
        private const int BorderWidth = 50;

        public void DisplayHeader(string title)
        {
            Console.Clear();
            string border = new string('=', BorderWidth);
            Console.WriteLine(border);

            if (title.Length >= BorderWidth)
            {
                Console.WriteLine(title);
            }
            else
            {
                int padding = (BorderWidth - title.Length) / 2;
                string paddedTitle = title.PadLeft(padding + title.Length);
                Console.WriteLine(paddedTitle);
            }

            Console.WriteLine(border);
        }

        public void DisplayFooter()
        {
            Console.WriteLine(new string('=', BorderWidth));
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey(true);
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }

        public void ShowStartWindow()
        {
            DisplayHeader("Добро пожаловать в Больницу!");
            Console.WriteLine("\nНажмите любую клавишу, чтобы начать...");
            Console.ReadKey(true);
        }

        public void DisplayMainMenu()
        {
            DisplayHeader("Меню Больницы");
            Console.WriteLine($"{HospitalCommands.SortByFullName}. Отсортировать всех больных по ФИО");
            Console.WriteLine($"{HospitalCommands.SortByAge}. Отсортировать всех больных по возрасту");
            Console.WriteLine(
                $"{HospitalCommands.FilterPatientsByIllness}. Вывести больных с определенным заболеванием");
            Console.WriteLine($"{HospitalCommands.Exit}. Выход\n");
            Console.Write("Выберите действие: ");
        }

        public void DisplayPatients(List<Patient> patients)
        {
            DisplayHeader("Список Больных");

            if (patients.Count == 0)
            {
                Console.WriteLine("Нет данных для отображения.");
            }
            else
            {
                foreach (var patient in patients)
                {
                    Console.WriteLine(patient.ToString());
                }
            }

            DisplayFooter();
        }

        public void DisplayIllnessPrompt()
        {
            Console.Write("Введите название заболевания: ");
        }

        public void DisplayNoPatientsFound(string illness)
        {
            DisplayHeader("Результаты поиска");
            DisplayMessage($"Больные с заболеванием \"{illness}\" не найдены.");
            DisplayFooter();
        }
    }
}