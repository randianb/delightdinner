using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu;
using DelightDinner.Domain.Menu.MenuObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DelightDinner.Infrastructure.Configuration;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.OwnsOne(x => x.AverageRating);

        builder.Property(x => x.HostId)
            .ValueGeneratedNever()
            .HasConversion(
            id => id.Value,
            value => HostId.Create(value));
    }
}