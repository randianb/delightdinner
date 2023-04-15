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
    public GuestId GuestId { get; private set; }
    public BillId? BillId { get; private set; }
    public DateTime? ArrivalDateTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Reservation(
        uint guestCount,
        ReservationStatus reservationStatus,
        DateTime? arrivalDateTime,
        GuestId guestId,
        BillId? billId)
        : base(ReservationId.CreateUnique())
    {
        GuestId = guestId;
        BillId = billId;
        GuestCount = guestCount;
        ArrivalDateTime = arrivalDateTime;
        ReservationStatus = reservationStatus;
    }

    public static Reservation Create(
        uint guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId,
        BillId? billId = null,
        DateTime? arrivalDateTime = null)
    {
        return new(
            guestCount,
            reservationStatus,
            arrivalDateTime,
            guestId,
            billId);
    }

#pragma warning disable CS8618
    private Reservation()
    {
    }
#pragma warning restore CS8618
}