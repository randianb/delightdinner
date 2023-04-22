using DelightDinner.Domain.User;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IUserReposetory
{
    void Add(User user);

    User? GetUserByEmail(string email);    
}