using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Menus.Queries.ListMenus;

public class ListMenuQueryHandler : IRequestHandler<ListMenuQuery, ErrorOr<List<Menu>>>
{
    private readonly IMenuRepository _menuRepository;

    public ListMenuQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<List<Menu>>> Handle(ListMenuQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var hostId = HostId.Create(query.HostId);

        return _menuRepository.List(hostId);
    }
}