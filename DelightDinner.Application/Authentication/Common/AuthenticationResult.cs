using DelightDinner.Domain.User;

namespace DelightDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
