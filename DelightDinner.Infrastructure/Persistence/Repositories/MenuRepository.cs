using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Menu;

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
}