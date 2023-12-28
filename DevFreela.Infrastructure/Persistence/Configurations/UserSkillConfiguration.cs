using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DevFreela.Domain.Entities;

namespace DevFreela.Infrastructure.Persistence.Configurations;

internal class UserSkillConfiguration : BaseEntityConfiguration<UserSkill>
{
    public override void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        base.Configure(builder);
    }
}