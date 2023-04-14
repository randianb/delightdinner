using DelightDinner.Domain.User;
using DelightDinner.Domain.User.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DelightDinner.Infrastructure.Persistence.Configuration;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(x => x.FirstName)
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .HasMaxLength(50);

        builder.Property(x => x.Email)
            .HasMaxLength(50);

        builder.Property(x => x.Password)
            .HasMaxLength(50);
    }
}