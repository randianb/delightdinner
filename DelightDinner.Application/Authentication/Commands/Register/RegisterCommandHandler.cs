using DelightDinner.Application.Authentication.Common;
using DelightDinner.Application.Common.Interfaces.Authentication;
using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Common.Errors;
using DelightDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserReposetory _userReposetory;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserReposetory userReposetory)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userReposetory = userReposetory;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user doesn't exist.
        if (_userReposetory.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create user (generate unique ID) & Persist to DB.
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userReposetory.Add(user);

        // 3. Create a JWT-token. 
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}