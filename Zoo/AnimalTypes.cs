using System;
using System.Collections.Generic;

namespace Zoo
{
    public static class AnimalTypes
    {
        public static Dictionary<Type, Animals> AnimalsTypes = new Dictionary<Type, Animals>()
        {
            { typeof(Capybara), Animals.Capybara },
            { typeof(Cat), Animals.Cat },
            { typeof(Zebra), Animals.Zebra },
            { typeof(SecretaryBird), Animals.SecretaryBird },
            { typeof(Platypus), Animals.Platypus },
        };
    }
}