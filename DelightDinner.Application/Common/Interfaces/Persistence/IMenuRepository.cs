using DelightDinner.Domain.Menu;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}
