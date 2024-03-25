using System.Collections.Generic;
using System.Text;
using PassengerTrainConfigurator;

namespace Passenger_Train_Configurator
{
    public class Wagon
    {
        private readonly int _wagonNumber;
        private readonly List<Seat> _seats;

        public Wagon(int wagonNumber)
        {
            _wagonNumber = wagonNumber;
            _seats = new List<Seat>();
        }

        public Wagon(int wagonNumber, List<Seat> seats)
        {
            _wagonNumber = wagonNumber;
            _seats = seats;
        }

        public int Capacity => _seats.Count;

        /*public Seat GetSeat(int seatNumber)
        {
            bool isFound = false;
            int seatPosition = 0;

            while (isFound == false && seatPosition < _seats.Count)
            {
                if ()
            }

            return _seats[seatNumber].Clone();
        }*/

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Вагон - {_wagonNumber}:");

            if (_seats.Count != 0)
            {
                for(int i = 0; i < _seats.Count; i++)
                {
                    stringBuilder.AppendLine($"\t\tМесто {i + 1}. {_seats[i]}");
                }
            }
            else
            {
                stringBuilder.AppendLine($"\t\tВагон пустой");
            }

            return stringBuilder.ToString();
        }
    }
}