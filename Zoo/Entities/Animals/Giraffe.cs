using System;
using System.Collections.Generic;

namespace Zoo.Entities.Animals
{
    public sealed class Giraffe : Animal
    {
        private double _neckLength;

        public Giraffe(string name, string gender, string sound, double neckLength)
            : base(name, gender, sound)
        {
            _neckLength = neckLength;
        }

        public string EatFromTree()
        {
            return $"{Name} дотягивается до самых высоких листьев благодаря шее длиной {_neckLength} м.";
        }

        public string LookFar()
        {
            return $"{Name} осматривает окрестности с высоты своего роста.";
        }

        public override List<Func<string>> GetActions()
        {
            return new List<Func<string>>()
            {
                EatFromTree,
                LookFar
            };
        }

        public override Animal Copy()
        {
            return new Giraffe(Name, Gender, Sound, _neckLength);
        }
    }
}