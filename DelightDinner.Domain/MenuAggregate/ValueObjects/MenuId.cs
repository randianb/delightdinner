using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Common.Errors;

using ErrorOr;

namespace DelightDinner.Domain.Menu.MenuObjects;

public sealed class MenuId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        // TODO: enforce invariants
        return new(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        // TODO: enforce invariants
        return new(value);
    }

    public static ErrorOr<MenuId> Create(string value)
    {
        return !Guid.TryParse(value, out var guid) 
            ? (ErrorOr<MenuId>)Errors.Menu.InvalidMenuId 
            : (ErrorOr<MenuId>)new MenuId(guid);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private MenuId()
    {
    }
#pragma warning restore CS8618
}