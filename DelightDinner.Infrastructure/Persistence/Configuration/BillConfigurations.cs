using DelightDinner.Domain.BillAggregate;
using DelightDinner.Domain.BillAggregate.ValueObjects;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.GuestAggregate.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DelightDinner.Infrastructure.Persistence.Configuration;

public class BillConfigurations : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        ConfigureBillsTable(builder);
    }

    private void ConfigureBillsTable(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(b => b.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => BillId.Create(value));

        builder.Property(x => x.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(x => x.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(x => x.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.OwnsOne(x => x.Amount, pb => 
            pb.Property(b => b.Amount)
                .HasColumnType("decimal(5,4)"));
    }
}