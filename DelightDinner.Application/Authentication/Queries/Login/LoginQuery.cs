using DelightDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
