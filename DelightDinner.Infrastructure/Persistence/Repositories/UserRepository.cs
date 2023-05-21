using System.Runtime.CompilerServices;

using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.UserAggregate;

using Microsoft.EntityFrameworkCore;

namespace DelightDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserReposetory
{
    private readonly DelightDinnerDbContext _dbContext;

    public UserRepository(DelightDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(user => user.Email == email);
    }
}