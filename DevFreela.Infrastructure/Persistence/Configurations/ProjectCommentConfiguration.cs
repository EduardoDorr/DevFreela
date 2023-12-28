using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DevFreela.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Configurations;

internal class ProjectCommentConfiguration : BaseEntityConfiguration<ProjectComment>
{
    public override void Configure(EntityTypeBuilder<ProjectComment> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Content)
               .HasMaxLength(255)   
               .IsRequired();

        builder.Property(b => b.CreatedAt)
               .HasColumnType("datetime")
               .IsRequired();

        builder.HasOne(b => b.Project)
               .WithMany(b => b.Comments)
               .HasForeignKey(b => b.ProjectId);

        builder.HasOne(b => b.User)
               .WithMany(b => b.Comments)
               .HasForeignKey(b => b.UserId);
    }
}
