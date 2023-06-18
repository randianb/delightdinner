using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.GuestAggregate;
using DelightDinner.Domain.GuestAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;

namespace DelightDinner.Infrastructure.Persistence.Repositories;

public class GuestRepository : IGuestRepository
{
    private readonly DelightDinnerDbContext _dbContext;

    public GuestRepository(DelightDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Guest guest)
    {
        _dbContext.Add(guest);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(GuestId guestId)
    {
        return await _dbContext.Guests.AnyAsync(m => m.Id == guestId);
    }

    public async Task<Guest?> GetByIdAsync(GuestId guestId)
    {
        return await _dbContext.Guests.FirstOrDefaultAsync(x => x.Id == guestId);
    }

    public async Task UpdateAsync(Guest guest)
    {
        _dbContext.Update(guest);
        await _dbContext.SaveChangesAsync();
    }
}