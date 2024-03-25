using System;

namespace PassengerTrainConfigurator
{
    public class Seat
    {
        private SeatTypes _seatType;
        private string _number;

        public Seat(SeatTypes seatType, string number)
        {
            _seatType = seatType;
            _number = number;
            IsBooked = false;
        }

        public bool IsBooked { get; private set; }

        public void Book()
        {
            if (!IsBooked)
            {
                IsBooked = true;
            }
            else
            {
                throw new InvalidOperationException("Seat is already booked.");
            }
        }

        public void Release()
        {
            if (IsBooked)
            {
                IsBooked = false;
            }
            else
            {
                throw new InvalidOperationException("Seat is already free.");
            }
        }

        public override string ToString()
        {
            return $"Номер - {_number}, Тип - {_seatType}, Забронировано - {IsBooked}";
        }
    }

    public enum SeatTypes
    {
        First,
        Basic,
        Comfort
    }
}