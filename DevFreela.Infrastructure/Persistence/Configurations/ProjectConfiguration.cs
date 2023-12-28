using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DevFreela.Domain.Entities;

namespace DevFreela.Infrastructure.Persistence.Configurations;

internal class ProjectConfiguration : BaseEntityConfiguration<Project>
{
    public override void Configure(EntityTypeBuilder<Project> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Title)
               .HasMaxLength(50)
               .IsRequired();
        
        builder.Property(b => b.Description)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(b => b.TotalCost)
               .HasColumnType("numeric(18,2)")
               .IsRequired();

        builder.Property(b => b.CreatedAt)
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(b => b.StartedAt)
               .HasColumnType("datetime");

        builder.Property(b => b.FinishedAt)
               .HasColumnType("datetime");

        builder.HasOne(b => b.Client)
               .WithMany(c => c.OwnedProjects)
               .HasForeignKey(b => b.ClientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Freelancer)
               .WithMany(c => c.FreelanceProjects)
               .HasForeignKey(b => b.FreelancerId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
