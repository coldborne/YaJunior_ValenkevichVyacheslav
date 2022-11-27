using System;

namespace Gladiator_fights
{
    public interface ICloneable
    {
        object Clone();
    }
    
    public abstract class Fighter
    {
        public int HealPoints { get;  set; }
        public int Damage { get;  set; }
        public string Name { get; }

        protected Fighter()
        {
            Name = GenerateName();
        }

        public virtual void ShowStats()
        {
            Console.WriteLine(
                $"Имя - {Name}, " +
                $"Количество жизней - {HealPoints}, " +
                $"Количество урона - {Damage}, " +
                $"Класс - {FighterClassName.FightersName[GetType()]}");
        }

        public virtual object Clone()
        {
            return new object();
        }

        private string GenerateName()
        {
            int nameLength = 5;
            string name = "";

            while (name.Length < nameLength)
            {
                Char symbol = (char)UserUtils.Random.Next(97, 123);
                if (Char.IsLetterOrDigit(symbol))
                    name += symbol;
            }

            return name;
        }
    }

    public abstract class Magician : Fighter
    {
        public int Mana { get; protected set; }

        public override void ShowStats()
        {
            Console.WriteLine(
                $"Имя - {Name}, Количество жизней - {HealPoints}, " +
                $"Количество урона - {Damage}, " +
                $"Количество маны - {Mana}, " +
                $"Класс - {FighterClassName.FightersName[GetType()]}");
        }
    }

    public class Cleric : Magician, ICloneable
    {
        public Cleric()
        {
            HealPoints = 70;
            Damage = 50;
            Mana = 100;
        }
    }

    public class Thief : Fighter, ICloneable
    {
        public Thief()
        {
            HealPoints = 100;
            Damage = 40;
        }
        
        public object Clone()
        {
            return new Thief();
        }
    }

    public class Paladin : Fighter, ICloneable
    {
        public Paladin()
        {
            HealPoints = 150;
            Damage = 100;
        }
        
        public object Clone()
        {
            return new Paladin();
        }
    }

    public class Mage : Magician, ICloneable
    {
        public Mage()
        {
            HealPoints = 80;
            Damage = 30;
            Mana = 100;
        }
        
        public object Clone()
        {
            return new Mage();
        }
    }

    public class Barbarian : Fighter, ICloneable
    {
        public Barbarian()
        {
            HealPoints = 200;
            Damage = 80;
        }
        
        public object Clone()
        {
            return new Barbarian();
        }
    }
}