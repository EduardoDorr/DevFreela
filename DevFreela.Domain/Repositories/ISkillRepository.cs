using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories;

public interface ISkillRepository
{
    void Create(Skill skill);
    void Delete(Skill skill);
    Task<IEnumerable<Skill>> GetAllAsync();
    Task<Skill?> GetByIdAsync(int id);
    Task<bool> SaveChangesAsync();
    void Update(Skill skill);
}