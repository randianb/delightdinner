using DelightDinner.Domain.Entities;

namespace DelightDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
