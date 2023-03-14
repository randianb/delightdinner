using DelightDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using DelightDinner.Domain.Common.Errors;
using DelightDinner.Application.Services.Authentication.Common;
using DelightDinner.Application.Services.Authentication.Commands;
using DelightDinner.Application.Services.Authentication.Query;
using MediatR;
using DelightDinner.Application.Authentication.Commands.Register;

namespace DelightDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }    

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationQueryService.Login(
            request.Email,
            request.Password);

        if (authResult.IsError && authResult.FirstError == Errors.Authentiacation.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }
    
    private static AuthenticatioResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticatioResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token);
    }
}
