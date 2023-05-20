using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.DinnerAggregate;
using DelightDinner.Domain.HostAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;

namespace DelightDinner.Infrastructure.Persistence.Repositories;

public class DinnerRepository : IDinnerRepository
{
    private readonly DelightDinnerDbContext _dbContext;

    public DinnerRepository(DelightDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Dinner dinner)
    {
        _dbContext.Add(dinner);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Dinner>> ListAsync(HostId hostId)
    {
        return await _dbContext.Dinners
            .Where(x => x.HostId == hostId)
            .ToListAsync();
    }
}