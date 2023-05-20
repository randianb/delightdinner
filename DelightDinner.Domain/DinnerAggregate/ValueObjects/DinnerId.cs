using DelightDinner.Domain.Common.Models.Identities;

namespace DelightDinner.Domain.Dinner.ValueObjects;

public sealed class DinnerId : AggregateRootId<Guid> 
{
    public DinnerId(Guid value) : base(value)
    {
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static DinnerId Create(Guid value)
    {
        return new(value);
    }
}