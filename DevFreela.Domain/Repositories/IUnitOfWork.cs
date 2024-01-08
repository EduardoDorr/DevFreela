namespace DevFreela.Domain.Repositories;

public interface IUnitOfWork
{
    IProjectRepository Projects { get; }
    IUserRepository Users { get; }
    ISkillRepository Skills { get; }

    Task<int> SaveChangesAsync();
}