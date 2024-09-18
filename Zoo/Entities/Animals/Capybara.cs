namespace Zoo.Entities.Animals
{
    public sealed class Capybara : Animal
    {
        private bool _isLovesWater;

        public Capybara(string name, string gender, string sound)
            : base(name, gender, sound)
        {
            _isLovesWater = true;
        }

        public string Swim()
        {
            return _isLovesWater
                ? $"{Name} плавает в воде, наслаждаясь прохладой."
                : $"{Name} плавает в воде, но без удовольствия.";
        }

        public override Animal Copy()
        {
            return new Capybara(Name, Gender, Sound);
        }
    }
}