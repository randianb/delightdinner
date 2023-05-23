using DelightDinner.Domain.DinnerAggregate;
using DelightDinner.Domain.HostAggregate.ValueObjects;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IDinnerRepository
{
    Task AddAsync(Dinner dinner);

    Task<List<Dinner>> ListAsync(HostId hostId);
}