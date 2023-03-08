using DelightDinner.Domain.Entities;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IUserReposetory
{
    User? GetUserByEmail(string email);

    void Add(User user);
}
