using DelightDinner.Domain.Bill;
using DelightDinner.Domain.Dinner;
using DelightDinner.Domain.Host;
using DelightDinner.Domain.Menu;
using DelightDinner.Domain.MenuReview;
using DelightDinner.Domain.User;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DelightDinner.Infrastructure.Persistence;

public class DelightDinnerDbContext : DbContext
{
    public DelightDinnerDbContext(DbContextOptions<DelightDinnerDbContext> options)
        : base(options) 
    { 
    }

    DbSet<Menu> Menus { get; set; } = null!;

    DbSet<MenuReview> MenuReviews { get; set; } = null!;

    DbSet<Bill> Bills { get; set; } = null!;

    DbSet<User> Users { get; set; } = null!;

    DbSet<Host> Hosts { get; set; } = null!;

    DbSet<Dinner> Dinners { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(DelightDinnerDbContext).Assembly);

        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}