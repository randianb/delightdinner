using DelightDinner.Domain.Bill.ValueObjects;
using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;

namespace DelightDinner.Domain.Dinner.Entities;

internal class Reservation : Entity<ReservationId>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    
    private Reservation(
        ReservationId reservationId,
        DinnerId dinnerId,
        GuestId guestId,
        BillId billId)
        : base(reservationId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        BillId = billId;
    }

    public static Reservation Create(
        DinnerId dinnerId,
        GuestId guestId,
        BillId billId)
    {
        return new(
            ReservationId.CreateUnique(),
            dinnerId,
            guestId,
            billId);
    }
}