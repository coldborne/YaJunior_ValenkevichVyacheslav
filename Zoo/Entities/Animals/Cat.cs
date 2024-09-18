namespace Zoo.Entities.Animals
{
    public sealed class Cat : Animal
    {
        private int _livesCount;

        public Cat(string name, string gender, string sound)
            : base(name, gender, sound)
        {
            _livesCount = 9;
        }

        public string Purr()
        {
            return $"{Name} мурлычет от удовольствия.";
        }

        public string Scratch()
        {
            return
                $"{Name} точит когти о дерево. Возможно, количество жизней уменьшится. Сейчас жизней осталось: {_livesCount}";
        }

        public override Animal Copy()
        {
            return new Cat(Name, Gender, Sound);
        }
    }
}