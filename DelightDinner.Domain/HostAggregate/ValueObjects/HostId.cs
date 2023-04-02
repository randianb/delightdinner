using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.User.ValueObjects;

namespace DelightDinner.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public string Value { get; private set; }

    public HostId(string value)
    {
        Value = value;
    }

    public static HostId Create(UserId userId)
    {
        // TODO: enforce invariants
        return new HostId($"HostId_{userId.Value}");
    }

    public static HostId Create(string hostId)
    {
        // TODO: enforce invariants
        return new HostId(hostId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}