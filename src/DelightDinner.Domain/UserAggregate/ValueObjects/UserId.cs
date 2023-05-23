using DelightDinner.Domain.Common.Models.Identities;

namespace DelightDinner.Domain.UserAggregate.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{
    public UserId(Guid value) : base(value)
    {
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new(value);
    }
}