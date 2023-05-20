using DelightDinner.Domain.BillAggregate.ValueObjects;
using DelightDinner.Domain.DinnerAggregate;
using DelightDinner.Domain.DinnerAggregate.Enums;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu.MenuObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DelightDinner.Infrastructure.Persistence.Configuration;

public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnersTable(builder);
        ConfigurateReservationsTable(builder);
    }

    private void ConfigurateReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(x => x.Reservations, res =>
        {
            res.ToTable("Reservations");

            res.WithOwner()
                .HasForeignKey("DinnerId");

            res.HasKey("DinnerId", "Id");

            res.Property(x => x.Id)
                .HasConversion(
                    id => id.Value,
                    value => ReservationId.Create(value));

            res.Property(x => x.ReservationStatus)
                .HasConversion(
                    status => status.Value,
                    value => ReservationStatus.FromValue(value));

            res.Property(x => x.GuestId)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

            res.Property(x => x.BillId)
                .HasConversion(
                    id => id!.Value,
                    value => BillId.Create(value));
        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(x => x.Name)
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.Status)
            .HasConversion(
                status => status.Value,
                value => DinnerStatus.FromValue(value));

        builder.OwnsOne(x => x.Price, p => p.Property(i => i.Amount)
            .HasColumnType("decimal(10,4)"));

        builder.Property(d => d.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(d => d.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.OwnsOne(d => d.Location);
    }
}