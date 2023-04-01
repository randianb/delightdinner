using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Menu.MenuObjects;

namespace DelightDinner.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }
    public float Price { get; }

    private MenuItem(
        MenuItemId menuItemId,
        string name,
        string description,
        float price)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public static MenuItem Create(
        string name,
        string description,
        float price)
    {
        return new(
            MenuItemId.CreateUnique(),
            name,
            description,
            price);
    }
}