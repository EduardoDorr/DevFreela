using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
    void Create(User user);
    void Update(User user);
    void Delete(User user);
}