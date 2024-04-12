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

        public int FreeSeatsCount
        {
            get
            {
                int count = 0;

                foreach (Seat seat in _seats)
                {
                    if (seat.IsBooked == false)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public int Capacity => _seats.Count;

        public List<Seat> GetFreeSeats()
        {
            List<Seat> seats = new List<Seat>();

            foreach (Seat seat in _seats)
            {
                if (seat.IsBooked == false)
                {
                    seats.Add(seat);
                }
            }

            return seats;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Вагон - {_wagonNumber}:");

            if (_seats.Count != 0)
            {
                int lasWagonPosition = _seats.Count - 1;

                for (int i = 0; i < lasWagonPosition; i++)
                {
                    stringBuilder.AppendLine($"\t\tМесто {i + 1}. {_seats[i]}");
                }

                stringBuilder.Append($"\t\tМесто {lasWagonPosition + 1}. {_seats[lasWagonPosition]}");
            }
            else
            {
                stringBuilder.AppendLine($"\t\tВагон пустой");
            }

            return stringBuilder.ToString();
        }
    }
}