using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.Enums;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu.MenuObjects;

namespace DelightDinner.Domain.Dinner;

public class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<ReservationId> _reservationIds = new();

    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime StartedDateTime { get;}
    public DateTime EndedDateTime { get; }
    public ReservationStatus Status { get; }
    public bool IsPublic { get; }
    public uint MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; set; }
    public IReadOnlyList<ReservationId> ReservationIds => _reservationIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        ReservationStatus reservationStatus,
        bool isPublic,
        uint maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime) 
        : base(dinnerId)
    {
        HostId = hostId;
        MenuId = menuId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        ReservationStatus reservationStatus,
        bool isPublic,
        uint maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            reservationStatus,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            location,
            createdDateTime,
            updatedDateTime);
    }
}