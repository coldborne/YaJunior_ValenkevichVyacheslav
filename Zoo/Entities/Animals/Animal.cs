using Zoo.Entities.Interfaces;

namespace Zoo.Entities.Animals
{
    public abstract class Animal : ICopyable<Animal>
    {
        protected Animal(string name, string gender, string sound)
        {
            Name = name;
            Gender = gender;
            Sound = sound;
        }

        public string Name { get; }
        public string Gender { get; }
        public string Sound { get; }

        public abstract Animal Copy();

        public override string ToString()
        {
            return $"{Name} ({Gender}). Издаёт звук: {Sound}";
        }
    }
}