using Ardalis.SmartEnum;

namespace DelightDinner.Domain.DinnerAggregate.Enums;

public sealed class DinnerStatus : SmartEnum<DinnerStatus>
{
    public DinnerStatus(string name, int value) 
        : base(name, value) 
    { 
    }

    public static readonly DinnerStatus Upcomming = new DinnerStatus(nameof(Upcomming), 1);
    public static readonly DinnerStatus InProgress = new DinnerStatus(nameof(InProgress), 2);
    public static readonly DinnerStatus Ended = new DinnerStatus(nameof(Ended), 3);
    public static readonly DinnerStatus Canceled = new DinnerStatus(nameof(Canceled), 4);
}