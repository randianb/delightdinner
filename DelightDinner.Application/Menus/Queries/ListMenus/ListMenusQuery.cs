using DelightDinner.Domain.Menu;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Menus.Queries.ListMenus;

public record ListMenusQuery(string HostId)
    : IRequest<ErrorOr<List<Menu>>>;