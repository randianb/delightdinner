using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.User.ValueObjects;

public class UserId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    public UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private UserId()
    {
    }
#pragma warning restore CS8618
}