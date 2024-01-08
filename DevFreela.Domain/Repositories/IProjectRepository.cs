using DevFreela.Domain.Dtos;
using DevFreela.Domain.Models;
using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories;

public interface IProjectRepository
{
    Task<PaginationResult<Project>> GetAllAsync(string query, int page = 1, int pageSize = 2);
    Task<Project?> GetByIdAsync(int id);
    Task<ProjectDetailsDto?> GetByIdWithDetailsAsync(int id);
    void Create(Project project);
    void Update(Project project);
    void Delete(Project project);
    Task<bool> SaveChangesAsync();
    void CreateComment(ProjectComment comment);
}