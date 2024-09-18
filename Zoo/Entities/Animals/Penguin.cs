namespace Zoo.Entities.Animals
{
    public sealed class Penguin : Animal
    {
        private bool _canFly;

        public Penguin(string name, string gender, string sound)
            : base(name, gender, sound)
        {
            _canFly = false;
        }

        public string Swim()
        {
            return $"{Name} ныряет глубоко и быстро плавает под водой.";
        }

        public string Slide()
        {
            return $"{Name} скользит по льду на животе, как на санках. Умеет ли летать: {_canFly}";
        }

        public override Animal Copy()
        {
            return new Penguin(Name, Gender, Sound);
        }
    }
}