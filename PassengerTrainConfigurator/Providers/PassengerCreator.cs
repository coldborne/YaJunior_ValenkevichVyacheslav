using System.Text;
using PassengerTrainConfigurator;

namespace Passenger_Train_Configurator
{
    public class PassengerCreator
    {
        private const string UpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerChars = "abcdefghijklmnopqrstuvwxyz";

        public Passenger CreatePassenger()
        {
            int surnameLength = 7;
            int nameLength = 5;
            int patronymicLength = 10;

            string surname = GenerateWord(surnameLength);
            string name = GenerateWord(nameLength);
            string patronymic = GenerateWord(patronymicLength);

            return new Passenger(surname, name, patronymic);
        }

        private string GenerateWord(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(UpperChars[RandomProvider.Next(0, LowerChars.Length - 1)]);

            for(int i = 1; i < length; i++)
            {
                stringBuilder.Append(LowerChars[RandomProvider.Next(0, LowerChars.Length - 1)]);
            }

            return stringBuilder.ToString();
        }
    }
}