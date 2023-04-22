using DelightDinner.Domain.Dinner;
using DelightDinner.Domain.Host.ValueObjects;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IDinnerRepository
{
    void Add(Dinner dinner);

    List<Dinner> List(HostId hostId);
}