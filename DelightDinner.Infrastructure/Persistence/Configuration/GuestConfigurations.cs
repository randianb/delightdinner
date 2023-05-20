using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.Guest;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.User.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DelightDinner.Infrastructure.Persistence.Configuration;

public class GuestConfigurations : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConfigureGuestsTable(builder);
        ConfigureGuestUpcommingDinnersIdsTable(builder);
        ConfigureGuestPastDinnersIdsTable(builder);
        ConfigureGuestPendingDinnersIdsTable(builder);
        ConfigureGuestMenuReviewIdsTable(builder);
        ConfigureGuestRatingsTable(builder);
        ConfigureGuestBillIdsTable(builder);
    }

    private void ConfigureGuestBillIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.BillIds, bid =>
        {
            bid.ToTable("GuestBillIds");

            bid.WithOwner().HasForeignKey("GuestId");

            bid.HasKey("Id");

            bid.Property(x => x.Value)
                .HasColumnName("BillId");
        });

        builder.Metadata.FindNavigation(nameof(Guest.BillIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestRatingsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.Ratings, rid =>
        {
            rid.ToTable("GuestRatings");

            rid.WithOwner().HasForeignKey("GuestId");

            rid.HasKey("Id", "GuestId");

            rid.Property(x => x.Id)
                .HasColumnName("GuestRatingId")
                .HasConversion(
                    id => id.Value,
                    value => GuestRatingId.Create(value));

            rid.Property(x => x.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));

            rid.Property(x => x.DinnerId)
                .HasConversion(
                    id => id.Value,
                    value => DinnerId.Create(value));

            rid.OwnsOne(x => x.Rating);
        });

        builder.Metadata.FindNavigation(nameof(Guest.Ratings))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestMenuReviewIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.MenuReviewIds, mid =>
        {
            mid.ToTable("GuestMenuReviewIds");

            mid.WithOwner().HasForeignKey("GuestId");

            mid.HasKey("Id");

            mid.Property(x => x.Value)
                .HasColumnName("MenuReviewId");
        });

        builder.Metadata.FindNavigation(nameof(Guest.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestPendingDinnersIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PendingDinnerIds, ped =>
        {
            ped.ToTable("GuestPendingDinnersIds");

            ped.WithOwner().HasForeignKey("GuestId");

            ped.HasKey("Id");

            ped.Property(x => x.Value)
                .HasColumnName("DinnerId");
        });

        builder.Metadata.FindNavigation(nameof(Guest.PendingDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestPastDinnersIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PastDinnerIds, pdid =>
        {
            pdid.ToTable("GuestPastDinnersIds");

            pdid.WithOwner().HasForeignKey("GuestId");

            pdid.HasKey("Id");

            pdid.Property(x => x.Value)
                .HasColumnName("DinnerId");
        });

        builder.Metadata.FindNavigation(nameof(Guest.PastDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestUpcommingDinnersIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.UpcommingDinnerIds, udid =>
        {
            udid.ToTable("GuestUpcommingDinnersIds");

            udid.WithOwner().HasForeignKey("GuestId");

            udid.HasKey("Id");

            udid.Property(x => x.Value)
                .HasColumnName("DinnerId");
        });

        builder.Metadata.FindNavigation(nameof(Guest.UpcommingDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(g => g.FirstName)
            .HasMaxLength(50);

        builder.Property(g => g.LastName)
            .HasMaxLength(50);

        builder.Property(g => g.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }
}