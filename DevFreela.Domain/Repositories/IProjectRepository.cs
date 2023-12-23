using DevFreela.Domain.Dtos;
using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<ProjectDetailsDto?> GetByIdWithDetailsAsync(int id);
    void Create(Project project);
    void Update(Project project);
    void Delete(Project project);
    Task<bool> SaveChangesAsync();
    void CreateComment(ProjectComment comment);
}