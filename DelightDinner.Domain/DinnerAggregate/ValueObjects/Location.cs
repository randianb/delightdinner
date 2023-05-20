using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.DinnerAggregate.ValueObjects;

public class Location : ValueObject
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public float Latitude { get; private set; }
    public float Longtitute { get; private set; }

    private Location(
        string name,
        string address,
        float latitude,
        float longtitute)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longtitute = longtitute;
    }   

    public static Location Create(
        string name,
        string address,
        float latitude,
        float longtitute)
    {
        // TODO: enforce invariants
        return new(
            name,
            address,
            latitude,
            longtitute);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longtitute;
    }

#pragma warning disable CS8618
    private Location()
    {
    }
#pragma warning restore CS8618
}