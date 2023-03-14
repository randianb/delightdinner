using DelightDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace DelightDinner.Application.Services.Authentication.Query;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
