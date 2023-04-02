using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Menu.MenuObjects;

namespace DelightDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    public string Name { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly(); 

    private MenuSection(
        
        string name,
        string description,
        List<MenuItem> items,
        MenuSectionId? menuSectionId = null)
        : base(menuSectionId ?? MenuSectionId.CreateUnique())
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem>? items = null)
    {
        return new(
            name,
            description,
            items ?? new());
    }
}