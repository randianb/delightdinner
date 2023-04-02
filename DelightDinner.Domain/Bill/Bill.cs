using DelightDinner.Domain.Common.Entities;
using DelightDinner.Domain.Bill.ValueObjects;
using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;

namespace DelightDinner.Domain.Bill;

public class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Amount { get; }

    public DateTime CreateDateTime { get; }
    public DateTime UpdateDateTime { get; }

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
        return new(
            dinnerId,
            guestId,
            hostId,
            price,
            createDateTime,
            updateDateTime);
    }
}