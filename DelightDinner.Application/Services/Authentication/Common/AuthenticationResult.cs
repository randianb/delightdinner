using DelightDinner.Domain.Entities;

namespace DelightDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);