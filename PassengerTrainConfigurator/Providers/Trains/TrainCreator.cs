using System.Collections.Generic;
using Passenger_Train_Configurator.Providers;

namespace Passenger_Train_Configurator
{
    public class TrainCreator
    {
        private WagonCreator _wagonCreator = new WagonCreator();

        private char _startNumberSymbol = 'a';
        private char _endNumberSymbol = 'z';

        public Train Create(string trainNumber, int wagonAmount)
        {
            int minimumWagonAmount = 5;
            int maximumWagonAmount = 20;

            List<Wagon> wagons = new List<Wagon>();

            for(int i = 1; i <= wagonAmount; i++)
            {
                Wagon wagon = _wagonCreator.Create(i, 10);
                wagons.Add(wagon);
            }

            return new Train(trainNumber, wagons);
        }

        public string GenerateTrainNumber()
        {
            const int NameLength = 5;
            string trainNumber = "";

            while (trainNumber.Length < NameLength)
            {
                char symbol = (char)RandomProvider.Next(_startNumberSymbol, _endNumberSymbol);

                if (char.IsLetterOrDigit(symbol))
                {
                    trainNumber += symbol;
                }
            }

            return trainNumber;
        }
    }
}