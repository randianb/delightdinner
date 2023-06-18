using DelightDinner.Domain.HostAggregate;
using DelightDinner.Domain.HostAggregate.ValueObjects;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IHostRepository
{
    Task AddAsync(Host host);   

    Task<Host?> GetByIdAsync(HostId hostId);

    Task<bool> ExistsAsync(HostId hostId);

    Task UpdateAsync(Host host);
}