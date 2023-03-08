using DelightDinner.Domain.Entities;

namespace DelightDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);