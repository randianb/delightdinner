using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Guest.ValueObjects;

public class GuestRatingId : ValueObject
{
    public GuestRatingId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static GuestRatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
