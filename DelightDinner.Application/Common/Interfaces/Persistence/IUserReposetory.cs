using DelightDinner.Domain.User;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IUserReposetory
{
    User? GetUserByEmail(string email);

    void Add(User user);
}
