using DelightDinner.Domain.UserAggregate;

namespace DelightDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);