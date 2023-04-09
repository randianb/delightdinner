using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    public int Value { get; private set; }

    public Rating(int value)
    {
        Value = value;
    }

    public static Rating Create(int value)
    {
        // TODO: Enforce invariants
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}