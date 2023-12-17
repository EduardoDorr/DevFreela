using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DevFreela.Domain.Entities;

namespace DevFreela.Infrastructure.Persistence.Configurations;

internal class SkillConfiguration : BaseEntityConfiguration<Skill>
{
    public override void Configure(EntityTypeBuilder<Skill> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Description)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(b => b.CreatedAt)
               .HasColumnType("datetime")
               .IsRequired();

        builder.HasMany(b => b.UserSkills)
               .WithOne(u => u.Skill)
               .HasForeignKey(b => b.SkillId);
    }
}