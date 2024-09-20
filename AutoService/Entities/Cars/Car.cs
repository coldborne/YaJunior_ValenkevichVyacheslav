using AutoService.Entities.Parts;

namespace AutoService.Entities.Cars;

public class Car
{
    private List<Part> _parts;

    public Car(string model, List<Part> parts)
    {
        Model = model;
        _parts = parts;
    }

    public string Model { get; }

    public List<Part> GetBrokenParts()
    {
        List<Part> brokenParts = new List<Part>();

        foreach (Part part in _parts)
        {
            if (part.IsBroken)
            {
                brokenParts.Add(part);
            }
        }

        return brokenParts;
    }

    public bool IsFullyRepaired()
    {
        foreach (Part part in _parts)
        {
            if (part.IsBroken)
            {
                return false;
            }
        }

        return true;
    }
}