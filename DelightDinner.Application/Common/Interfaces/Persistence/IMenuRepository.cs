using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu;
using DelightDinner.Domain.Menu.MenuObjects;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);

    bool Exists(MenuId menuId);

    List<Menu> List(HostId hostId);   
}