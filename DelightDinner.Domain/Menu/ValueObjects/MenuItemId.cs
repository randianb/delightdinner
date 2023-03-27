using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Menu.MenuObjects;

public sealed class MenuItemId : ValueObject
{
    public MenuItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
