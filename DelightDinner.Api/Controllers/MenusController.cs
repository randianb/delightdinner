using DelightDinner.Contracts.Menu;

using Microsoft.AspNetCore.Mvc;

namespace DelightDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        await Task.CompletedTask;
        
        return Ok(request);
    }
}