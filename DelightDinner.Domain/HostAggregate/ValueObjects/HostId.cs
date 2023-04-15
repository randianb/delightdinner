using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.User.ValueObjects;

namespace DelightDinner.Domain.Host.ValueObjects;

public sealed class HostId : AggregateRootId<string>
{
    public override string Value { get; protected set; }

    public HostId(string value)
    {
        Value = value;
    }

    public static HostId Create(UserId userId)
    {
        // TODO: enforce invariants
        return new($"HostId_{userId.Value}");
    }

    public static HostId Create(string hostId)
    {
        // TODO: enforce invariants
        return new(hostId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private HostId()
    {
    }
#pragma warning restore CS8618
}