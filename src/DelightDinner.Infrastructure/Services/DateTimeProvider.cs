using DelightDinner.Application.Common.Interfaces.Services;

namespace DelightDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
