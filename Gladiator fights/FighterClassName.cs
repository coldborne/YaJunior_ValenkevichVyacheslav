using System;
using System.Collections.Generic;

namespace Gladiator_fights
{
    public static class FighterClassName
    {
        public static Dictionary<Type, string> FightersName = new Dictionary<Type, string>()
        {
            { typeof(Cleric), "Клерик" },
            { typeof(Thief), "Вор" },
            { typeof(Paladin), "Паладин" },
            { typeof(Mage), "Маг" },
            { typeof(Barbarian), "Варвар" },
        };
    }
}