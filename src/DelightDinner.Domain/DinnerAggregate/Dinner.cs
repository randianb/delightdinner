using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.DinnerAggregate.Entities;
using DelightDinner.Domain.DinnerAggregate.Enums;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.DinnerAggregate.Events;
using DelightDinner.Domain.HostAggregate.ValueObjects;
using DelightDinner.Domain.MenuAggregate.MenuObjects;

namespace DelightDinner.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId, Guid>
{
    private readonly List<Reservation> _reservations = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public DinnerStatus Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public Uri ImageUrl { get; private set; }
    public Location Location { get; private set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();    
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Uri imageUrl,
        Location location) 
        : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        Status = DinnerStatus.Upcomming;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Uri imageUrl,
        Location location)
    {
        // TODO: Enforce invariants
        var dinner = new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location);

        dinner.AddDomainEvent(new DinnerCreated(dinner));

        return dinner;
    }

#pragma warning disable CS8618
    private Dinner()
    {
    }
#pragma warning restore CS8618
}