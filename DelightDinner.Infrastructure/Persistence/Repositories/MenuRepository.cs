using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu;
using DelightDinner.Domain.Menu.MenuObjects;

using Microsoft.EntityFrameworkCore;

namespace DelightDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly DelightDinnerDbContext _dbContext;

    public MenuRepository(DelightDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Menu menu)
    {
        _dbContext.Add(menu);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(MenuId menuId)
    {
        return await _dbContext.Menus.AnyAsync(m => m.Id == menuId);
    }

    public async Task<List<Menu>> ListAsync(HostId hostId)
    {
        return await _dbContext.Menus
            .Where(m => m.HostId == hostId)
            .ToListAsync();
    }

    public async Task<Menu?> GetByIdAsync(MenuId menuId)
    {
        return await _dbContext.Menus.FirstOrDefaultAsync(x => x.Id == menuId);
    }

    public async Task UpdateAsync(Menu menu)
    {
        _dbContext.Update(menu);
        await _dbContext.SaveChangesAsync();
    }
}