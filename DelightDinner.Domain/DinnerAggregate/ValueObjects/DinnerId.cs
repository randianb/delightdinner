using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Dinner.ValueObjects;

public sealed class DinnerId : AggregateRootId<Guid> 
{
    public override Guid Value { get; protected set; }

    public DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static DinnerId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}