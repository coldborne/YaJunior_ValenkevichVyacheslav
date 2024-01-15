namespace PlayerDatabase
{
    public class Player
    {
        private static int _numberForGenerateId = 1;

        private int _level;

        public Player(string nickname)
        {
            Id = _numberForGenerateId++;
            _level = 1;
            Nickname = nickname;
        }
        
        public string Nickname { get; private set; }
        public int Id { get; private set; }
        public bool IsBanned { get; private set; }

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