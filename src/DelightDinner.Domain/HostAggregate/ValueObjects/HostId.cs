using DelightDinner.Domain.Common.Models.Identities;
using DelightDinner.Domain.UserAggregate.ValueObjects;

namespace DelightDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : AggregateRootId<string>
{
    public HostId(string value) : base(value)
    {
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
}