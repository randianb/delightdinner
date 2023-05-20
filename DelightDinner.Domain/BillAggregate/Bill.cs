using DelightDinner.Domain.BillAggregate.ValueObjects;
using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.GuestAggregate.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;

namespace DelightDinner.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId, string>
{
    public DinnerId DinnerId { get; private set; }
    public GuestId GuestId { get; private set; }
    public HostId HostId { get; private set; }
    public Price Amount { get; private set; }
    public DateTime CreateDateTime { get; private set; }
    public DateTime UpdateDateTime { get; private set; }

    private Bill(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createDateTime,
        DateTime updateDateTime) 
        : base(BillId.Create(dinnerId, guestId))
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Amount = price;
        CreateDateTime = createDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createDateTime,
        DateTime updateDateTime)
    {
        // TODO: enforce invariants
        return new(
            dinnerId,
            guestId,
            hostId,
            price,
            createDateTime,
            updateDateTime);
    }

#pragma warning disable CS8618
    private Bill()
    {
    }
#pragma warning restore CS8618
}