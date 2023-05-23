using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.GuestAggregate.ValueObjects;

public class GuestRatingId : ValueObject
{
    public Guid Value { get; private set; }

    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static GuestRatingId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private GuestRatingId()
    {
    }
#pragma warning restore CS8618
}