﻿using DelightDinner.Domain.Host;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.User.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DelightDinner.Infrastructure.Persistence.Configuration;

public class HostConfigurations : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostsTable(builder);
        ConfigureMenuIdsTable(builder);
        ConfigureDinnerIdsTable(builder);
    }

    private void ConfigureDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(x => x.DinnerIds, did =>
        {
            did.ToTable("DinnerIds");

            did.WithOwner()
                .HasForeignKey("HostId");

            did.HasKey("Id");

            did.Property(x => x.Value)
                .HasColumnName("HostDinnerId");
        });

        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(x => x.MenuIds, mid =>
        {
            mid.ToTable("MenuIds");

            mid.WithOwner()
                .HasForeignKey("HostId");

            mid.HasKey("Id");

            mid.Property(x => x.Value)
                .HasColumnName("HostMenuId");
        });

        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureHostsTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(x => x.FirstName)
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .HasMaxLength(50);

        builder.OwnsOne(x => x.AverageRating);

        builder.Property(x => x.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }
}