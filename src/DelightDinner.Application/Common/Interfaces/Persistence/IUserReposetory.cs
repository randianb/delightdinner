using DelightDinner.Domain.UserAggregate;

namespace DelightDinner.Application.Common.Interfaces.Persistence;

public interface IUserReposetory
{
    Task AddAsync(User user);

    Task<User?> GetUserByEmailAsync(string email);    
}