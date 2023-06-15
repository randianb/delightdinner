using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Common.ValueObjects;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.HostAggregate.ValueObjects;
using DelightDinner.Domain.MenuAggregate.Entities;
using DelightDinner.Domain.MenuAggregate.MenuObjects;
using DelightDinner.Domain.MenuAggregate.Events;
using DelightDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace DelightDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _menuSections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _menuSections.AsReadOnly();
    public HostId HostId { get; private set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection> sections)
        : base(menuId)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        AverageRating = averageRating;
        _menuSections = sections;
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection>? sections = null)
    {
        // TODO: enforce invariants
        var menu = new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AverageRating.CreateNew(),
            sections ?? new());

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }

    public void AddDinnerId(DinnerId dinnerId)
    {
        _dinnerIds.Add(dinnerId);
    }

    public void AddMenuReviewId(MenuReviewId menuReviewId)
    {
        _menuReviewIds.Add(menuReviewId);
    }

#pragma warning disable CS8618
    private Menu()
    {
    }
#pragma warning restore CS8618
}