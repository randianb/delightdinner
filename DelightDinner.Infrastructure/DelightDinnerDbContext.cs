using Microsoft.EntityFrameworkCore;

namespace DelightDinner.Infrastructure;

public class DelightDinnerDbContext : DbContext
{
    public DelightDinnerDbContext(DbContextOptions<DelightDinnerDbContext> options)
        : base(options) { }


}