using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DevFreela.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Configurations;

internal class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(b => b.Email)
               .HasMaxLength(80)
               .IsRequired();

        builder.HasIndex(b => b.Email)
               .IsUnique();

        builder.Property(b => b.BirthDate)
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(b => b.CreatedAt)
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(b => b.Password)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(b => b.Role)
               .HasMaxLength(25)
               .IsRequired();

        builder.HasMany(b => b.UserSkills)
               .WithOne(u => u.User)
               .HasForeignKey(b => b.UserId);
    }
}