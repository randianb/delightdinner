using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;

namespace DelightDinner.Domain.Bill.ValueObjects;

public class BillId : AggregateRootId<string>
{
    public override string Value { get; protected set; }

    private BillId(string value)
    {
        Value = value;
    }

    private BillId(DinnerId dinnerId, GuestId guestId) 
    {
        Value = $"Bill_{dinnerId.Value}_{guestId.Value}";
    }

    public static BillId Create(string value)
    {
        return new(value);
    }

    public static BillId Create(DinnerId dinnerId, GuestId guestId)
    {
        return new(dinnerId, guestId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private BillId()
    {
    }
#pragma warning restore CS8618
}