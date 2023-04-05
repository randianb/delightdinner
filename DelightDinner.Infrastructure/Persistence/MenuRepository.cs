using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Menu;

namespace DelightDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}
