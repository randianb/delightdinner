using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.UserAggregate;

namespace DelightDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserReposetory
{
    private readonly DelightDinnerDbContext _dbContext;

    public UserRepository(DelightDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users
            .SingleOrDefault(u => u.Email == email);
    }
}