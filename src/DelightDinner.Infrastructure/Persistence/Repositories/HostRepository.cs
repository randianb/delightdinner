using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.GuestAggregate;
using DelightDinner.Domain.GuestAggregate.ValueObjects;
using DelightDinner.Domain.HostAggregate;
using DelightDinner.Domain.HostAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;

namespace DelightDinner.Infrastructure.Persistence.Repositories;

public class HostRepository : IHostRepository
{
    private readonly DelightDinnerDbContext _dbContext;

    public HostRepository(DelightDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Host host)
    {
        _dbContext.Add(host);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(HostId hostId)
    {
        return await _dbContext.Hosts.AnyAsync(m => m.Id == hostId);
    }

    public async Task<Host?> GetByIdAsync(HostId hostId)
    {
        return await _dbContext.Hosts.FirstOrDefaultAsync(x => x.Id == hostId);
    }

    public async Task UpdateAsync(Host host)
    {
        _dbContext.Update(host);
        await _dbContext.SaveChangesAsync();
    }
}