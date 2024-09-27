namespace DelayDefinition;

public class StewFactory
{
    private StewCreator _stewCreator;

    public StewFactory(StewCreator stewCreator)
    {
        _stewCreator = stewCreator;
    }
    
    public List<Stew> Create(int count)
    {
        List<Stew> stews = new List<Stew>();

        for (int i = 0; i < count; i++)
        {
            stews.Add(_stewCreator.Create());
        }

        return stews;
    }
}