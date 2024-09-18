namespace Zoo.Entities.Factories
{
    public class AviaryFactory
    {
        public Aviary CreateAviary(string name)
        {
            return new Aviary(name);
        }
    }
}