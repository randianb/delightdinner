using DelightDinner.Domain.Menu;

using Microsoft.EntityFrameworkCore;

namespace DelightDinner.Infrastructure;

public class DelightDinnerDbContext : DbContext
{
    public DelightDinnerDbContext(DbContextOptions<DelightDinnerDbContext> options)
        : base(options) { }

    DbSet<Menu> Menus { get; set; } = null!;
}