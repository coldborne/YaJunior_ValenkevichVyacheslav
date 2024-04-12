namespace Passenger_Train_Configurator
{
    public class UniqueTrainNumberGenerator
    {
        private int _numberCounter = 0;
        private int _maxTrainNumberCount = 1000;
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private char[] _currentChars = new char[4] { 'A', 'A', 'A', 'A' };

        public string GenerateUniqueTrainNumber()
        {
            if (_numberCounter == _maxTrainNumberCount)
            {
                _numberCounter = 0;
                IncrementChars();
            }

            string numberPart = _numberCounter.ToString("D4");
            _numberCounter++;

            return $"{new string(_currentChars)}-{numberPart}";
        }

        private void IncrementChars()
        {
            int position = _currentChars.Length - 1;

            while (position >= 0)
            {
                int charIndex = Chars.IndexOf(_currentChars[position]);

                if (charIndex == Chars.Length - 1)
                {
                    _currentChars[position] = 'A';
                    position--;
                }
                else
                {
                    _currentChars[position] = Chars[charIndex + 1]; // иначе просто инкрементируем букву
                    break;
                }
            }
        }
    }
}