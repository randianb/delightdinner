using DelightDinner.Domain.Common.Errors;
using DelightDinner.Domain.Common.Models.Identities;

using ErrorOr;

namespace DelightDinner.Domain.Menu.MenuObjects;

public sealed class MenuId : AggregateRootId<Guid>
{
    private MenuId(Guid value) : base(value)
    {
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
}