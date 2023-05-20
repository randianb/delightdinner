using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.HostAggregate.ValueObjects;
using DelightDinner.Domain.MenuAggregate;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Menus.Queries.ListMenus;

public class ListMenusQueryHandler : IRequestHandler<ListMenusQuery, ErrorOr<List<Menu>>>
{
    private readonly IMenuRepository _menuRepository;

    public ListMenusQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<List<Menu>>> Handle(ListMenusQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var hostId = HostId.Create(query.HostId);

        return await _menuRepository.ListAsync(hostId);
    }
}
