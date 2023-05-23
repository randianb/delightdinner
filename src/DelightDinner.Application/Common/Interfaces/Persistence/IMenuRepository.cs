using DelightDinner.Domain.HostAggregate.ValueObjects;
using DelightDinner.Domain.MenuAggregate;
using DelightDinner.Domain.MenuAggregate.MenuObjects;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    Task AddAsync(Menu menu);

    Task<bool> ExistsAsync(MenuId menuId);

    Task<List<Menu>> ListAsync(HostId hostId);

    Task<Menu?> GetByIdAsync(MenuId menuId);

    Task UpdateAsync(Menu menu);
}