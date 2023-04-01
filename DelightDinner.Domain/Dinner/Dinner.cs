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
    public bool StartedDateTime { get;}
    public bool EndedDateTime { get; }
    public ReservationStatus Status { get; }
    public bool IsPublic { get; }
    public uint MaxGuests { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public bool ImageUrl { get; }
    public IReadOnlyList<ReservationId> ReservationIds => _reservationIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Dinner(
        DinnerId dinnerId,
        HostId hostId,
        MenuId menuId,
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
        HostId hostId,
        MenuId menuId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            DinnerId.CreateUnique(),
            hostId,
            menuId,
            createdDateTime,
            updatedDateTime);
    }
}
