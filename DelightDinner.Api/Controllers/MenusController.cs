using DelightDinner.Application.Menus.Commands.CreateMenu;
using DelightDinner.Application.Menus.Queries.ListMenus;
using DelightDinner.Contracts.Menu;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DelightDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mdeiator;

    public MenusController(IMapper mapper, ISender mdeiator)
    {
        _mapper = mapper;
        _mdeiator = mdeiator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));

        var createMenuResult = await _mdeiator.Send(command);

        return createMenuResult.Match(
            menu => Ok(_mapper.Map<CreateMenuResponse>(menu)),
            errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> ListMenus(string hostId)
    {
        var query = _mapper.Map<ListMenusQuery>(hostId);

        var listMenusResult = await _mdeiator.Send(query);

        return listMenusResult.Match(
            menus => Ok(menus.Select(menu => _mapper.Map<CreateMenuResponse>(menu))),
            errors => Problem(errors));
    }
}