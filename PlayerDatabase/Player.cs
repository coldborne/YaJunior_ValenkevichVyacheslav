namespace PlayerDatabase
{
    public class Player
    {
        private static int _numberForGenerateId = 0;

        private int _level;
        private string _nickname;

        public int Id { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string nickname)
        {
            Id = _numberForGenerateId + 1;
            _numberForGenerateId++;
            _level = 1;
            _nickname = nickname;
        }

        public void Ban()
        {
            IsBanned = true;
        }
        
        public void Unban()
        {
            IsBanned = false;
        }
    }
}