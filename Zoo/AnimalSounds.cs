namespace Zoo
{
    public abstract class AnimalSound
    {
        public enum Sounds
        {
            Ghe,
            Meow,
            Huhu,
            Erere,
            Ururu
        }

        public abstract Sounds GetSound();
    }

    public class CapybaraSound : AnimalSound
    {
        public override Sounds GetSound()
        {
            return Sounds.Ghe;
        }
    }

    public class CatSound : AnimalSound
    {
        public override Sounds GetSound()
        {
            return Sounds.Meow;
        }
    }

    public class ZebraSound : AnimalSound
    {
        public override Sounds GetSound()
        {
            return Sounds.Huhu;
        }
    }

    public class SecretaryBirdSound : AnimalSound
    {
        public override Sounds GetSound()
        {
            return Sounds.Erere;
        }
    }

    public class PlatypusSound : AnimalSound
    {
        public override Sounds GetSound()
        {
            return Sounds.Ururu;
        }
    }
}