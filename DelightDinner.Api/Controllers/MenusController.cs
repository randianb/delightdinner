using DelightDinner.Application.Menus.Commands.CreateMenu;
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

        var command = _mapper.Map<CreateMenuCommand>(request);

        var createMenuResult = await _mdeiator.Send(command);
        
        return createMenuResult.Match(
                       menu => Ok(_mapper.Map<CreateMenuResponse>(menu)),
                       error => Problem(error));
    }
}