using DelightDinner.Domain.Common.Models.Identities;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.GuestAggregate.ValueObjects;

namespace DelightDinner.Domain.BillAggregate.ValueObjects;

public class BillId : AggregateRootId<string>
{
    private BillId(string value) : base(value)
    {
    }

    private BillId(DinnerId dinnerId, GuestId guestId) 
        : base($"Bill_{dinnerId.Value}_{guestId.Value}")
    {
    }

    public static BillId Create(string value)
    {
        return new(value);
    }

    public static BillId Create(DinnerId dinnerId, GuestId guestId)
    {
        return new(dinnerId, guestId);
    }
}