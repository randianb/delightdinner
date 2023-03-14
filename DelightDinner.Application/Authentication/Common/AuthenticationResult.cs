using DelightDinner.Domain.Entities;

namespace DelightDinner.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
