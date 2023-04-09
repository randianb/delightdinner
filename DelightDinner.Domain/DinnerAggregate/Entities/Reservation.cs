using DelightDinner.Domain.Bill.ValueObjects;
using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.Enums;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;

namespace DelightDinner.Domain.Dinner.Entities;

public class Reservation : Entity<ReservationId>
{
    public uint GuestCount { get; private set; }
    public ReservationStatus ReservationStatus { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public GuestId GuestId { get; private set; }
    public BillId BillId { get; private set; }
    public DateTime ArrivalDateTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Reservation(
        ReservationId reservationId,
        uint guestCount,
        ReservationStatus reservationStatus,
        DinnerId dinnerId,
        GuestId guestId,
        BillId billId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(reservationId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        BillId = billId;
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
        uint guestCount,
        ReservationStatus reservationStatus,
        DinnerId dinnerId,
        GuestId guestId,
        BillId billId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            reservationStatus,
            dinnerId,
            guestId,
            billId,
            createdDateTime,
            updatedDateTime);
    }

#pragma warning disable CS8618
    private Reservation()
    {
    }
#pragma warning restore CS8618
}