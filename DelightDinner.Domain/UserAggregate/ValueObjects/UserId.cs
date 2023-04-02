using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    public UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}