using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Menu.MenuObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        // TODO: enforce invariants
        return new(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        // TODO: enforce invariants
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}