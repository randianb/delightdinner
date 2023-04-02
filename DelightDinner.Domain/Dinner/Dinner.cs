using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.Entities;
using DelightDinner.Domain.Dinner.Enums;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu.MenuObjects;

namespace DelightDinner.Domain.Dinner;

public class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();

    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get;}
    public DateTime? EndedDateTime { get; }
    public DinnerStatus Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public Uri ImageUrl { get; }
    public Location Location { get; set; }

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

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
        return new(
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
    }
}