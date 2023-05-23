using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.MenuAggregate.MenuObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        // TODO: enforce invariants
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        // TODO: enforce invariants
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private MenuItemId()
    {
    }
#pragma warning restore CS8618
}