using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Bill.ValueObjects;

public class BillId : ValueObject
{
    public BillId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
