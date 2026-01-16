using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using application.domain.Entities.User;

namespace application.Infrastructure.Persistence.Configurations
{
    public sealed class CustomerConfiguration
      : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasConversion(
                    id => id.Value,
                    value => new UserId(value))
                .ValueGeneratedNever();

            builder.Property(c => c.Email)
                .HasConversion(
                    email => email.Value,
                    value => Email.Create(value))
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
