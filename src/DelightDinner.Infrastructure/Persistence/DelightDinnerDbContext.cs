using DelightDinner.Domain.BillAggregate;
using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.DinnerAggregate;
using DelightDinner.Domain.GuestAggregate;
using DelightDinner.Domain.HostAggregate;
using DelightDinner.Domain.MenuAggregate;
using DelightDinner.Domain.MenuReviewAggregate;
using DelightDinner.Domain.UserAggregate;
using DelightDinner.Infrastructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        ChangeTracker.StateChanged += OnEntityStateChanged;

    }

    private void OnEntityStateChanged(object? sender, EntityStateChangedEventArgs e)
    {
        Console.WriteLine("z1");

        var entry = e.Entry;

        Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);

        Console.WriteLine("Status: {0}", entry.State);

        Console.WriteLine("z1");
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
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
}