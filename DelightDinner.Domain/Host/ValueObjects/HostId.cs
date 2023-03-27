using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public HostId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
