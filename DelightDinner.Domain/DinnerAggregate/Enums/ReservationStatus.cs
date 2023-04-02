using Ardalis.SmartEnum;

namespace DelightDinner.Domain.Dinner.Enums;

public class ReservationStatus : SmartEnum<ReservationStatus>
{
    public ReservationStatus(string name, int value)
        : base(name, value) { }

    public static readonly ReservationStatus PendingGuestConfirmation = new ReservationStatus(nameof(PendingGuestConfirmation), 1);
    public static readonly ReservationStatus Reserved = new ReservationStatus(nameof(Reserved), 2);
    public static readonly ReservationStatus Cancelled = new ReservationStatus(nameof(Cancelled), 3);
}