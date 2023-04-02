using DelightDinner.Domain.Common.Enums;

namespace DelightDinner.Domain.Dinner.ValueObjects;

public class Price
{
    public float Amount { get; }
    public Currency Currency { get; }
}
