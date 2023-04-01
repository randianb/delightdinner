using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Dinner.ValueObjects;

public sealed class DinnerId : ValueObject 
{
    public DinnerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}