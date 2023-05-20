using DelightDinner.Domain.Common.Models.Identities;

namespace DelightDinner.Domain.Guest.ValueObjects;

public class GuestId : AggregateRootId<Guid>
{
    private GuestId(Guid value) : base(value)
    {
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static GuestId Create(Guid value)
    {
        return new(value);
    }
}