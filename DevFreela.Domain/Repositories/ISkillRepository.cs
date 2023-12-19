using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllAsync();
    Task<Skill?> GetByIdAsync(int id);
}