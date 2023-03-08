using DelightDinner.Application.Common.Interfaces.Authentication;
using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Entities;

namespace DelightDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserReposetory _userReposetory;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserReposetory userReposetory)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userReposetory = userReposetory;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userReposetory.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with this email already exist.");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (_userReposetory.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with this email already exist.");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userReposetory.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user, 
            token);
    }
}
