using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Guest.ValueObjects;

public class GuestId : ValueObject
{
    public Guid Value { get; private set; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static GuestId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}