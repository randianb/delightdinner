using DelightDinner.Domain.Menu;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Menus.Queries.ListMenus;

public record ListMenuQuery(string HostId)
    : IRequest<ErrorOr<List<Menu>>>;
