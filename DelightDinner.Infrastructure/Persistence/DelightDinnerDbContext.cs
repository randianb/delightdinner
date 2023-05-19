using DelightDinner.Domain.Bill;
using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner;
using DelightDinner.Domain.Guest;
using DelightDinner.Domain.Host;
using DelightDinner.Domain.Menu;
using DelightDinner.Domain.MenuReview;
using DelightDinner.Domain.User;
using DelightDinner.Infrastructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DelightDinner.Infrastructure.Persistence;

public class DelightDinnerDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public DelightDinnerDbContext(
        DbContextOptions<DelightDinnerDbContext> options, 
        PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Menu> Menus { get; set; } = null!;

    public DbSet<MenuReview> MenuReviews { get; set; } = null!;

    public DbSet<Bill> Bills { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Host> Hosts { get; set; } = null!;

    public DbSet<Guest> Guests { get; set; } = null!;

    public DbSet<Dinner> Dinners { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(DelightDinnerDbContext).Assembly);

        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}