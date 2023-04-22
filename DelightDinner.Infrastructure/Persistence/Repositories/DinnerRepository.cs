using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Dinner;
using DelightDinner.Domain.Host.ValueObjects;

namespace DelightDinner.Infrastructure.Persistence.Repositories;

public class DinnerRepository : IDinnerRepository
{
    private readonly DelightDinnerDbContext _dbContext;

    public DinnerRepository(DelightDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Dinner dinner)
    {
        _dbContext.Add(dinner);
        _dbContext.SaveChanges();
    }

    public List<Dinner> List(HostId hostId)
    {
        return _dbContext.Dinners
            .Where(x => x.HostId == hostId)
            .ToList();
    }
}