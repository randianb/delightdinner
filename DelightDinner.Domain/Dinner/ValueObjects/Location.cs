using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Dinner.ValueObjects;

public class Location : ValueObject
{
    public string Name { get; }
    public string Address { get; }
    public float Latitude { get; }
    public float Longtitute { get; }

    private Location(string name, string address, float latitude, float longtitute)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longtitute = longtitute;
    }

    public static Location Create(string name, string address, float latitude, float longtitute)
    {
        // TODO: enforce invariants
        return new Location(name, address, latitude, longtitute);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longtitute;
    }
}