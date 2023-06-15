using DelightDinner.Domain.GuestAggregate;
using DelightDinner.Domain.GuestAggregate.ValueObjects;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IGuestRepository
{
    Task AddAsync(Guest guest);

    Task<bool> ExistsAsync(GuestId guestId);

    Task<Guest?> GetByIdAsync(GuestId guestId);

    Task UpdateAsync(Guest guest);
}