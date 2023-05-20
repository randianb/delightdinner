using DelightDinner.Domain.UserAggregate;

namespace DelightDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}