using System;

namespace PassengerTrainConfigurator
{
    public class Seat
    {
        private SeatTypes _seatType;

        public Seat(SeatTypes seatType)
        {
            _seatType = seatType;
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
            return $"Тип - {_seatType}. Забронировано - {IsBooked}";
        }
    }

    public enum SeatTypes
    {
        First,
        Basic,
        Comfort
    }
}