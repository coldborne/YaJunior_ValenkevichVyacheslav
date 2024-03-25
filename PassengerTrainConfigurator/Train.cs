using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassengerTrainConfigurator;

namespace Passenger_Train_Configurator
{
    public class Train
    {
        private string _number;
        private List<Wagon> _wagons;

        public Train(string number)
        {
            _number = number;
            _wagons = new List<Wagon>();
        }

        public Train(string number, List<Wagon> wagons)
        {
            _number = number;
            _wagons = wagons;
        }

        public int Capacity
        {
            get
            {
                int capacity = 0;

                foreach (Wagon wagon in _wagons)
                {
                    capacity += wagon.Capacity;
                }

                return capacity;
            }
        }

        /*public void SetPassenger(Wagon wagon, Seat seat, Passenger passenger)
        {
            int indexOfWagon = _wagons.IndexOf(wagon);

            if (indexOfWagon == -1)
            {
                throw new ArgumentException();
            }

            _wagons[indexOfWagon].SetPassenger(seat, passenger);
        }

        public List<Seat> GetSeatsWithoutPassanger()
        {
            List<Seat> seats = new List<Seat>();

            foreach (Wagon wagon in _wagons)
            {
                seats.InsertRange(seats.Count, wagon.GetSeatsWithoutPassanger());
            }

            return seats;
        }

        public Seat GetSeat(int wagonNumber, int seatNumber)
        {
            if (wagonNumber <= 0 || wagonNumber > _wagons.Count)
            {
                throw new ArgumentException("Переданы некорректные данные номера вагона");
            }

            return _wagons[wagonNumber].GetSeat(seatNumber);
        }*/

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Поезд {_number}:");

            if (_wagons.Count != 0)
            {
                for(int i = 0; i < _wagons.Count; i++)
                {
                    stringBuilder.AppendLine($"\t{_wagons[i]}");
                }
            }
            else
            {
                stringBuilder.AppendLine($"\tПоезд пустой");
            }

            return stringBuilder.ToString();
        }
    }
}