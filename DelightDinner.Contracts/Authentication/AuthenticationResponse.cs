namespace DelightDinner.Contracts.Authentication;

public record AuthenticatioResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);