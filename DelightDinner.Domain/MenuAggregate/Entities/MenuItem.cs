using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.MenuAggregate.MenuObjects;

namespace DelightDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private MenuItem(string name, string description)
        : base(MenuItemId.CreateUnique())
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        // TODO: enforce invariants
        return new(name, description);
    }

#pragma warning disable CS8618
    private MenuItem()
    {
    }
#pragma warning restore CS8618
}