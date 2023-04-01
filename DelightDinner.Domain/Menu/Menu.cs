using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu.Entities;
using DelightDinner.Domain.Menu.MenuObjects;
using DelightDinner.Domain.MenuReview.ValueObjects;

namespace DelightDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _section = new();
    private readonly List<DinnerId> _dinnerId = new();
    private readonly List<MenuReviewId> _menuReviewId = new();

    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections => _section.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerId.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewId.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            createdDateTime,
            updatedDateTime);
    }
}