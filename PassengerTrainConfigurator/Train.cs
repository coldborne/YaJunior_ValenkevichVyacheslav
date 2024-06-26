using System.Collections.Generic;
using System.Text;
using PassengerTrainConfigurator;

namespace Passenger_Train_Configurator
{
    public class Train
    {
        private List<Wagon> _wagons;

        public Train(string number, Direction direction, List<Wagon> wagons)
        {
            Number = number;
            Direction = direction;
            _wagons = wagons;
        }

        public string Number { get; }
        public Direction Direction { get; private set; }

        public int GetFreeSeatsCount()
        {
            int count = 0;

            foreach (Wagon wagon in _wagons)
            {
                count += wagon.FreeSeatsCount;
            }

            return count;
        }

        public int GetCapacity()
        {
            int capacity = 0;

            foreach (Wagon wagon in _wagons)
            {
                capacity += wagon.Capacity;
            }

            return capacity;
        }

        public List<Seat> GetFreeSeats()
        {
            List<Seat> seats = new List<Seat>();

            foreach (Wagon wagon in _wagons)
            {
                seats.InsertRange(seats.Count, wagon.GetFreeSeats());
            }

            return seats;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Направление - {Direction}");
            stringBuilder.AppendLine($"Поезд {Number}:");

            if (_wagons.Count != 0)
            {
                int lasTrainPosition = _wagons.Count - 1;

                for (int i = 0; i < lasTrainPosition; i++)
                {
                    stringBuilder.AppendLine($"\t{_wagons[i]}");
                }

                stringBuilder.Append($"\t{_wagons[lasTrainPosition]}");
            }
            else
            {
                stringBuilder.AppendLine($"\tПоезд пустой");
            }

            return stringBuilder.ToString();
        }
    }
}