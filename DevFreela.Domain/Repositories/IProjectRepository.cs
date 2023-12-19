using DevFreela.Domain.Dtos;
using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<ProjectDetailsDto?> GetByIdAsync(int id);
}