using DelightDinner.Domain.Bill.ValueObjects;
using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.Enums;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;

namespace DelightDinner.Domain.Dinner.Entities;

internal class Reservation : Entity<ReservationId>
{
    public uint GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

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
}