using AutoServiceGame.Entities.Extensions;
using AutoServiceGame.Entities.Parts;

namespace AutoServiceGame.Entities.Cars;

public class Car
{
    private List<Part> _parts;

    public Car(string model, List<Part> parts)
    {
        Model = model;
        _parts = parts;
    }

    public string Model { get; }

    public bool TryChangePart(Part unbrokenPart, out bool isRepaired)
    {
        isRepaired = false;

        if (unbrokenPart == null)
        {
            return false;
        }

        if (unbrokenPart.IsBroken)
        {
            return false;
        }

        for (int i = 0; i < _parts.Count; i++)
        {
            Part carPart = _parts[i];

            if (unbrokenPart.Equals(carPart))
            {
                if (carPart.IsBroken)
                {
                    isRepaired = true;
                }
                
                _parts[i] = unbrokenPart;

                return true;
            }
        }

        return false;
    }
    
    public List<Part> GetParts()
    {
        return _parts.Copy();
    }


    public List<Part> GetBrokenParts()
    {
        List<Part> brokenParts = new List<Part>();

        foreach (Part part in _parts)
        {
            if (part.IsBroken)
            {
                brokenParts.Add(part.Copy());
            }
        }

        return brokenParts;
    }
    
    public List<Part> GetUnbrokenParts()
    {
        List<Part> unbrokenParts = new List<Part>();

        foreach (Part part in _parts)
        {
            if (part.IsBroken == false)
            {
                unbrokenParts.Add(part.Copy());
            }
        }

        return unbrokenParts;
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