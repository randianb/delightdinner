using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu.MenuObjects;
using DelightDinner.Domain.MenuReview;
using DelightDinner.Domain.MenuReview.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DelightDinner.Infrastructure.Persistence.Configuration;

public class MenuReviewConfigurations : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        builder.ToTable("MenuReviews");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => MenuReviewId.Create(value));

        builder.OwnsOne(x => x.Rating);

        builder.Property(x => x.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(x => x.Comment)
            .HasMaxLength(300);

        builder.Property(x => x.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(x => x.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(x => x.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));
    }
}