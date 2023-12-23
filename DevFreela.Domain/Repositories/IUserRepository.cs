using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories;

public interface IUserRepository
{
    void Create(User user);
    void Delete(User user);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<bool> SaveChangesAsync();
    void Update(User user);
}