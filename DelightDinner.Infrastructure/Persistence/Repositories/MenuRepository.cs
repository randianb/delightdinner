using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu;
using DelightDinner.Domain.Menu.MenuObjects;

namespace DelightDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly DelightDinnerDbContext _dbContext;

    public MenuRepository(DelightDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }

    public bool Exists(MenuId menuId)
    {
        return _dbContext.Menus.Any(m => m.Id == menuId);
    }

    public List<Menu> List(HostId hostId)
    {
        return _dbContext.Menus
            .Where(m => m.HostId == hostId)
            .ToList();
    }
}